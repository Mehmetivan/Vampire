using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float MovementSpeed;

    [SerializeField] private Rigidbody2D body;



    void Update()
    {
        Vector2 direction = target.position - transform.position;
        direction.Normalize();

        //transform.position += (Vector3)(direction * MovementSpeed) * Time.deltaTime;
        body.linearVelocity = direction * MovementSpeed;


    }
}
