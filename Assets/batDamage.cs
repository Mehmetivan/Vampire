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
        if (!other.TryGetComponent(out playerHealth player)) return;

        victim = player;
        playerInRange = true;      // always track this

        if (armed) return;         // fuse already running, don't restart it
        timer = delay;
        armed = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.TryGetComponent(out playerHealth player)) return;
        if (player == victim) playerInRange = false;   // fuse keeps running
    }

    public void OnUpdate(float deltaTime)
    {
        if (!armed) return;

        timer -= deltaTime;
        if (timer <= 0f)
        {
            if (playerInRange && victim != null)
                victim.TakeDamage((int)stats.BatDamage);

            if (deathEffect != null)
                Instantiate(deathEffect, transform.position, Quaternion.identity);
                SoundEffects.Instance.PlayExplosion();
            Destroy(gameObject);   // dies no matter what
        }
    }
}