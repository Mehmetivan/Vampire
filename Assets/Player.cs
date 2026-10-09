using System.Collections;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Player : MonoBehaviour, IUpdateable, IFixedUpdateable
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private Rigidbody2D body;

    private float horizontal;

    private float vertical;

    private bool spacePressed;

    private bool canDash = true;
    private bool isDashing;

    private float dashingPower = 24f;

    private float dashingTime = 0.2f;

    private float dashingCooldown = 1f;

    [SerializeField] private SwordAttack sword;




    [SerializeField] private PlayerStats stats;

    [SerializeField] private TrailRenderer trailRenderer;

    [SerializeField] private Animator animator;


    [SerializeField] private SpriteRenderer spriteRenderer;




    //public float speed = stats.Speed;

    //private float speed = 2f;

    //private bool isFacingRight;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();

    }

    private void OnEnable()
    {
        GameUpdateManager.Instance.Register(this, UpdatePriority.High);
        GameUpdateManager.Instance.RegisterFixed(this, UpdatePriority.High);
        GameUpdateManager.Instance.PausedChanged += HandlePausedChanged;
    }
    private void OnDisable()
    {
        GameUpdateManager.Instance.Unregister(this);
        GameUpdateManager.Instance.UnregisterFixed(this);
        GameUpdateManager.Instance.PausedChanged -= HandlePausedChanged;
    }


    public void OnUpdate(float deltaTime)


    {


        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (horizontal > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (horizontal < 0)
        {
            spriteRenderer.flipX = true;
        }



        spacePressed = Input.GetKeyDown(KeyCode.Space);

        if ((spacePressed) && canDash)
        {
            StartCoroutine(Dash());
        }
        //can also put them into one vector2 and apply speed to the vector in FixedUpdate()


        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("isAttacking", true);
            sword.attack();


        }

    }

    public void OnFixedUpdate(float deltaTime) {

        if (isDashing) return;

        Vector2 direction = new Vector2(horizontal, vertical).normalized;

        body.linearVelocity = direction * stats.Speed;

        if (horizontal != 0 || vertical != 0)
        {
            animator.SetBool("isRunning", true);

        }
        else
        {
            animator.SetBool("isRunning", false);
        }


    }

    private void HandlePausedChanged(bool paused)
    {
        body.simulated = !paused;
    }


    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;

        Vector2 dir = new Vector2(horizontal, vertical).normalized;
        if (dir == Vector2.zero) dir = Vector2.right; // fallback if standing still
        SoundEffects.Instance.PlayDash();

        body.linearVelocity = dir * dashingPower;
        trailRenderer.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        trailRenderer.emitting = false;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    public void endAttack()
    {
        animator.SetBool("isAttacking", false);
    }





}
