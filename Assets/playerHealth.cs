using UnityEngine;

public class playerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private PlayerStats stats;

    [SerializeField] private Animator animator;
    public float health;

    public float MaxHealth => stats.MaxHealth;

    private void Awake()
    {
        if (stats == null) stats = GetComponent<PlayerStats>();
        health = stats.MaxHealth;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        animator.SetBool("isHurt", true);
        SoundEffects.Instance.PlayPlayerTakeDamage();
        if (health <= 0)
        {
            GameManager.Instance.LoseGame();
        }
    }

    public void Heal(float amount)
    {
        health = Mathf.Min(health + amount, stats.MaxHealth);
    }


    public void endHurt()
    {
        animator.SetBool("isHurt", false);
    }



}