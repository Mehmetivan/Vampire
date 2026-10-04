using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Player : MonoBehaviour, IUpdateable, IFixedUpdateable
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private Rigidbody2D body;

    private float horizontal;

    private float vertical;


    [SerializeField] private PlayerStats stats;

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

        //can also put them into one vector2 and apply speed to the vector in FixedUpdate()
    }

    public void OnFixedUpdate(float deltaTime) {

        body.linearVelocity = new Vector2(horizontal * stats.Speed, vertical * stats.Speed);

    }

    private void HandlePausedChanged(bool paused)
    {
        body.simulated = !paused;
    }


}
