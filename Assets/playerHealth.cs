using UnityEngine;

public class playerHealth : MonoBehaviour, IDamageable
{
    public int health = 10;
    public const int maxHealth = 10;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            //Destroy(gameObject);
            GameManager.Instance.LoseGame();
        }
    }


}
