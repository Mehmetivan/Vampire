using UnityEngine;

public class radiusAttack : MonoBehaviour
{
    //public int damage = 3;
    public float attackCooldown = 1f;

    [SerializeField] private PlayerStats stats;

    private float attackTimer = 0f;

    private void OnTriggerStay2D(Collider2D collision)
    {
        attackTimer -= Time.deltaTime;

        if (attackTimer <= 0f) {

            IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(stats.Damage);
                SoundEffects.Instance.PlayPlayerAttack();

                attackTimer = attackCooldown;
            }
        }

        
    }
    void Start()
    {
        
    }


}
