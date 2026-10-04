using UnityEngine;

public class Enemy : MonoBehaviour, IUpdateable
{
    Transform target;
    [SerializeField] float MovementSpeed;
    [SerializeField] private Rigidbody2D body;

    private Vector2 savedVelocity;


    public void SetTarget(Transform target) { this.target = target; }

    private void OnEnable()
    {
        var manager = GameUpdateManager.Instance;
        manager.Register(this, UpdatePriority.High);
        manager.PausedChanged += HandlePausedChanged;

        if (!manager.IsUpdating) Freeze(); // spawned while paused
    }

    private void OnDisable()
    {
        var manager = GameUpdateManager.Instance;
        if (manager == null) return;

        manager.Unregister(this);
        manager.PausedChanged -= HandlePausedChanged;
    }
    public void OnUpdate(float deltaTime)
    {
        Vector2 direction = ((Vector2)target.position - (Vector2)transform.position).normalized;
        body.linearVelocity = direction * MovementSpeed;
    }

    private void HandlePausedChanged(bool paused)
    {
        if (paused) Freeze();
        else Unfreeze();
    }

    private void Freeze()
    {
        savedVelocity = body.linearVelocity;
        body.linearVelocity = Vector2.zero;
        body.simulated = false;
    }

    private void Unfreeze()
    {
        body.simulated = true;
        body.linearVelocity = savedVelocity;
    }
}