using UnityEngine;

public class Enemy : MonoBehaviour, IUpdateable
{
    Transform target;
    [SerializeField] float MovementSpeed;

    [SerializeField] private Rigidbody2D body;

    //public playerHealth playerHealth;

    public void SetTarget(Transform target) {  this.target = target; }

    //public void SetPlayerHealth(playerHealth playerHealth) { this.playerHealth = playerHealth; }


    private void OnEnable()
    {
        GameUpdateManager.Instance.Register(this, UpdatePriority.High);

    }
    private void OnDisable()
    {
        GameUpdateManager.Instance.Unregister(this);
        


    }

    public void OnUpdate(float deltaTime) {

        Vector2 direction = target.position - transform.position;
        direction.Normalize();
        // Hello!

        //transform.position += (Vector3)(direction * MovementSpeed) * Time.deltaTime;
        body.linearVelocity = direction * MovementSpeed;

    }

    public void StopMoving()
    {
        //foreach(Enemy enemy in EnemySpawner.)
    }


}
