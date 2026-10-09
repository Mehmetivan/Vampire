using UnityEngine;

public class enemyDamage : MonoBehaviour

{

    [SerializeField] private EnemyStats stats;

    //public playerHealth playerHealth;
    //public float damage => stats.Damage;

    [SerializeField] private Animator animator;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();

        if (damageable != null)
        {
            damageable.TakeDamage(stats.Damage);
            animator.SetBool("isAttacking", true);
            SoundEffects.Instance.PlayEnemyAttack();
        }
    }

    public void endAttack()
    {
        animator.SetBool("isAttacking", false);
    }

}
