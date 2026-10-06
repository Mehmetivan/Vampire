using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   
    public static GameManager Instance; //to make it accessible anywhere in the game

    void Awake()
    {
        Instance = this;
        PauseGame();
    }

    public enum GameState
    {
        PlayingState = 0,
        PauseState = 1,
        UpgradeState = 2,
        LoseState= 3,

    }

    public GameState State = GameState.PauseState;

    [SerializeField] EnemySpawner enery_spawner;
    [SerializeField] Player player;  

    
    
    void Update()
    {

        switch (State)
        {
            case GameState.PlayingState:

                if (Input.GetKeyDown(KeyCode.P))
                {
                    PauseGame();
                    UIController.Instance.OnPauseClicked();
                }



                break;
            case GameState.PauseState:

                if (Input.GetKeyDown(KeyCode.P))
                {
                    ResumeGame();
                    UIController.Instance.OnResumeClicked();
                }

                break;
            case GameState.UpgradeState:
                break;
            case GameState.LoseState:
                break;
        }

    }


    public void PauseGame()
    {
        if (State == GameState.UpgradeState || State == GameState.LoseState) return;

        State = GameState.PauseState;
        GameUpdateManager.Instance.SetUpdating(false);
    }

    public void ResumeGame()
    {
        State = GameState.PlayingState;
        GameUpdateManager.Instance.SetUpdating(true);
    }

    public void LoseGame()
    {
        State = GameState.LoseState;
        
        UIController.Instance.OnLoseGame();

        GameUpdateManager.Instance.SetUpdating(false);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //UIController.Instance.OnPlayClicked();
    }
    public void EnterUpgradeState()
    {
        State = GameState.UpgradeState;
        GameUpdateManager.Instance.SetUpdating(false);
        UpgradeManager.Instance.ChangeEnemyStat(UpgradeType.Health, 1.1f);
    }




}
