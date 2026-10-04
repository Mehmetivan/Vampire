using UnityEngine;

public enum UpgradeType { Speed, Health, Damage }

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance;

    [SerializeField] private PlayerStats stats;
    [SerializeField] private int killsPerUpgrade = 10;

    [SerializeField] private playerHealth playerHealth;

    public int UpgradeCount { get; private set; }
    private int kills;
    private bool menuOpen;

    private void Awake() { Instance = this; }

    private void OnEnable() { enemyHealth.Killed += OnEnemyKilled; }
    private void OnDisable() { enemyHealth.Killed -= OnEnemyKilled; }

    private void OnEnemyKilled(enemyHealth enemy)
    {
        if (menuOpen) return;

        kills++;
        UIController.Instance.SetUpgradeProgress((float)kills / killsPerUpgrade);

        if (kills >= killsPerUpgrade)
        {
            menuOpen = true;
            GameManager.Instance.PauseGame();
            UIController.Instance.ShowUpgradeMenu();
        }
    }

    public void Choose(UpgradeType type)
    {
        switch (type)
        {
            case UpgradeType.Speed: stats.Speed *= 1.1f; break;
            case UpgradeType.Health:
                stats.MaxHealth += 2;
                playerHealth.Heal(stats.MaxHealth);
                break;
            case UpgradeType.Damage: stats.Damage *= 1.15f; break;
        }

        UpgradeCount++;
        kills = 0;
        menuOpen = false;
        UIController.Instance.SetUpgradeProgress(0);
        UIController.Instance.HideUpgradeMenu();
        GameManager.Instance.ResumeGame();
    }
}