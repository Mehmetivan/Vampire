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


    [SerializeField] private PlayerStats stats;

    [SerializeField] private TrailRenderer trailRenderer;




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

        spacePressed = Input.GetKeyDown(KeyCode.Space);

        if ((spacePressed) && canDash)
        {
            StartCoroutine(Dash());
        }

        //can also put them into one vector2 and apply speed to the vector in FixedUpdate()
    }

    public void OnFixedUpdate(float deltaTime) {

        if (isDashing) return;

        body.linearVelocity = new Vector2(horizontal * stats.Speed, vertical * stats.Speed);

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

        body.linearVelocity = dir * dashingPower;
        trailRenderer.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        trailRenderer.emitting = false;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }



}
