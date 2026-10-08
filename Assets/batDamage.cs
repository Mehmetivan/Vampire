using UnityEngine;

public class batDamage : MonoBehaviour, IUpdateable
{
    [SerializeField] private EnemyStats stats;
    [SerializeField] private float delay = 3f;

    [SerializeField] private GameObject deathEffect;

    private playerHealth victim;
    private bool playerInRange;
    private float timer;
    private bool armed;

    private void OnEnable()
    {
        GameUpdateManager.Instance.Register(this, UpdatePriority.High);
    }

    private void OnDisable()
    {
        if (GameUpdateManager.Instance != null)
            GameUpdateManager.Instance.Unregister(this);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        playerHealth player = other.GetComponentInParent<playerHealth>();
        Debug.Log($"Entered by {other.name}, playerHealth found: {player != null}", this);
        if (player == null) return;

        victim = player;
        playerInRange = true;

        if (armed) return;
        timer = delay;
        armed = true;
        Debug.Log("Fuse started", this);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        playerHealth player = other.GetComponentInParent<playerHealth>();
        if (player == null) return;

        if (player == victim) playerInRange = false;
    }

    public void OnUpdate(float deltaTime)
    {
        if (!armed) return;

        timer -= deltaTime;
        if (timer <= 0f)
        {
            Debug.Log("Fuse finished", this);
            if (playerInRange && victim != null)
                victim.TakeDamage((int)stats.BatDamage);

            if (deathEffect != null)
                Instantiate(deathEffect, transform.position, Quaternion.identity);
                SoundEffects.Instance.PlayExplosion();
            Destroy(gameObject);   // dies no matter what
        }
    }
}