using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class enemyHealth : MonoBehaviour, IDamageable
{

    [SerializeField] private EnemyStats stats;

    [SerializeField] private GameObject deathEffect;

    [SerializeField] private Animator animator;

    public float health;
    public float maxHealth => stats.MaxHealth;

    private void Awake()
    {
        if (stats == null) stats = GetComponent<EnemyStats>();
        health = stats.MaxHealth;
    }
    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        animator.SetBool("isHurt", true);

        SoundEffects.Instance.PlayEnemyTakeDamage();
        if (health <= 0)
        {
            Die();
        }
    }

    public static event System.Action<enemyHealth> Killed;

    public void Die()
    {

        if (deathEffect != null)
            Instantiate(deathEffect, transform.position, Quaternion.identity);

        Killed?.Invoke(this);
        //SoundEffects.Instance.PlayEnemyDeath();
        Destroy(gameObject); 
    }

    public void endHurt()
    {
        animator.SetBool("isHurt", false);
    }



}
