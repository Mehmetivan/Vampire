using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform target;
    [SerializeField] float MovementSpeed;

    [SerializeField] private Rigidbody2D body;

    //public playerHealth playerHealth;

    public void SetTarget(Transform target) {  this.target = target; }

    //public void SetPlayerHealth(playerHealth playerHealth) { this.playerHealth = playerHealth; }

    void Update()
    {
        Vector2 direction = target.position - transform.position;
        direction.Normalize();
        // Hello!

        //transform.position += (Vector3)(direction * MovementSpeed) * Time.deltaTime;
        body.linearVelocity = direction * MovementSpeed;


    }
}
