using UnityEngine;

public class enemyHealth : MonoBehaviour, IDamageable
{
    public int health;
    public int maxHealth = 4;
    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }


}
