using UnityEngine;

public class batDamage : MonoBehaviour, IUpdateable

{

    [SerializeField] private EnemyStats stats;
    [SerializeField] private float delay = 3f;

    private IDamageable victim;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (armed) return;

        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();

        if (damageable == null) return;

        victim = damageable;
        timer = delay;
        armed = true;

    }

    public void OnUpdate(float deltaTime)
    {
        if (!armed) return;
        timer -= deltaTime;
        if (timer <= 0f)
        {
            armed = false;

            if (victim == null) { victim.TakeDamage(stats.BatDamage);  }
            
            Destroy(gameObject);

        }
    }

}
