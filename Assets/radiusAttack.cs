using UnityEngine;

public class radiusAttack : MonoBehaviour
{
    public int damage = 3;
    public float attackCooldown = 1f;

    private float attackTimer = 0f;

    private void OnTriggerStay2D(Collider2D collision)
    {
        attackTimer -= Time.deltaTime;

        if (attackTimer <= 0f) {

            IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(damage);

                attackTimer = attackCooldown;
            }
        }

        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
