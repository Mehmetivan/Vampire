using UnityEngine;

public class Player : MonoBehaviour, IUpdateable, IFixedUpdateable
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private Rigidbody2D body;

    private float horizontal;

    private float vertical;
    private float speed = 2;
    //private bool isFacingRight;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        GameUpdateManager.Instance.Register(this, UpdatePriority.High);
        GameUpdateManager.Instance.RegisterFixed(this, UpdatePriority.High);
    }
    private void OnDisable() 
    { 
        GameUpdateManager.Instance.Unregister(this);
        GameUpdateManager.Instance.UnregisterFixed(this);
    }
   

    public void OnUpdate(float deltaTime)
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        //can also put them into one vector2 and apply speed to the vector in FixedUpdate()
    }

    public void OnFixedUpdate(float deltaTime) {

        body.linearVelocity = new Vector2(horizontal * speed, vertical * speed);

    }


}
