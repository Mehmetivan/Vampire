using System.Collections.Generic;
using UnityEngine;

public class GameUpdateManager : MonoBehaviour
{

    public static GameUpdateManager Instance;
    private readonly List<IUpdateable> highPriorityUpdates = new();
    private readonly List<IFixedUpdateable> highPriorityFixedUpdates = new();
    public bool IsUpdating { get; private set; }
    public event System.Action<bool> PausedChanged;

    public void SetUpdating(bool updating)
    {
        if (IsUpdating == updating) return; // nothing changed, do nothing
        IsUpdating = updating;
        PausedChanged?.Invoke(!updating);   // tell listeners: true = paused
    }

    //private const float UpdateInterval = 0.15f;
    //private float updateTimer;

    private void Iterate(List<IUpdateable> updates)
    {
        for (int i = 0; i < updates.Count; i++) updates[i].OnUpdate(Time.deltaTime);
    }

    private void Iterate(List<IFixedUpdateable> updates)
    {
        for (int i = 0; i < updates.Count; i++) updates[i].OnFixedUpdate(Time.fixedDeltaTime);
    }

    private void HighPriorityUpdate()
    {
        Iterate(highPriorityUpdates);
    }

    private void HighPriorityFixedUpdate()
    {
        Iterate(highPriorityFixedUpdates);
    }


    public void Register(IUpdateable update, UpdatePriority priority)
    {
        switch (priority)
        {
            case UpdatePriority.High:
                highPriorityUpdates.Add(update);

                break;

            case UpdatePriority.Medium:

                break;

            case UpdatePriority.Low:

                break;

            default: highPriorityUpdates.Add(update); break;

        }
    }

    public void Unregister(IUpdateable update) { 
        if(highPriorityUpdates.Remove(update)) return;
    
    }

    private void Awake()
    {
       if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;

        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (!IsUpdating) return;
        HighPriorityUpdate();
    }

    public void RegisterFixed(IFixedUpdateable update, UpdatePriority priority) {

        switch (priority) 
        {
            case UpdatePriority.High:
                highPriorityFixedUpdates.Add(update);

                break;
            
            case UpdatePriority.Medium:
                break;

            case UpdatePriority.Low:
                break;

            default: highPriorityFixedUpdates.Add(update); break;

        }
    
    }
    public void UnregisterFixed(IFixedUpdateable update)
    {
        if (highPriorityFixedUpdates.Remove(update)) return;
    }


    public void FixedUpdate()
    {
        if (!IsUpdating) return;
        HighPriorityFixedUpdate();
    }

}
