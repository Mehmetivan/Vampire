using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private PlayerStats stats;

    public GameObject attackPoint;
    public float attackRange;
    public LayerMask enemies;
    public void attack()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(attackPoint.transform.position, attackRange, enemies);
        //Debug.Log("attack() called");

        foreach (Collider2D enemyGameObject in enemy)
        {
            if(enemyGameObject.TryGetComponent(out Bat bat))
            {
                bat.Die();
                SoundEffects.Instance.PlayPlayerAttack();
            }

        }


    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.transform.position, attackRange);
    }

}
