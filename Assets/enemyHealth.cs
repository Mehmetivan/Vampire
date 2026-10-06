using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class enemyHealth : MonoBehaviour, IDamageable
{

    [SerializeField] private EnemyStats stats;

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
        if (health <= 0)
        {
            Die();
        }
    }

    public static event System.Action<enemyHealth> Killed;

    public void Die()
    {
        Killed?.Invoke(this);
        Destroy(gameObject); 
    }


}
