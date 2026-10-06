using UnityEngine;

public class enemyDamage : MonoBehaviour

{

    [SerializeField] private EnemyStats stats;

    //public playerHealth playerHealth;
    //public float damage => stats.Damage;

    
    void Start()
    {
        
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();

        if (damageable != null)
        {
            damageable.TakeDamage(stats.Damage);
        }
    }

}
