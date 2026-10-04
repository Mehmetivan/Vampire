using UnityEngine;

public class enemyHealth : MonoBehaviour, IDamageable
{
    public float health;
    public float maxHealth = 10f;
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
