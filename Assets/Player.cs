using UnityEngine;

public class Player : MonoBehaviour
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

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        //can also put them into one vector2 and apply speed to the vector in FixedUpdate()

        
        
    }

    private void FixedUpdate()
    {
        body.linearVelocity = new Vector2 (horizontal * speed, vertical * speed);


    }

}
