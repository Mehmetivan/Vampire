using UnityEngine;

public class GameManager : MonoBehaviour
{
   
    public static GameManager Instance; //to make it accessible anywhere in the game

    void Awake()
    {
        Instance = this;
    }

    public enum GameState
    {
        PlayingState = 0,
        PauseState = 1,
        UpgradeState = 2,
        LoseState= 3,

    }

    public GameState State = GameState.PlayingState;

    [SerializeField] EnemySpawner enery_spawner;
    [SerializeField] Player player;  
    
    void Update()
    {

        switch (State)
        {
            case GameState.PlayingState:

                if (Input.GetKeyDown(KeyCode.P))
                {
                    Time.timeScale = 0;
                    State = GameState.PauseState;

                }



                break;
            case GameState.PauseState:

                if (Input.GetKeyDown(KeyCode.P))
                {
                    Time.timeScale = 1;
                    State = GameState.PlayingState;
                }

                break;
            case GameState.UpgradeState:
                break;
            case GameState.LoseState:
                break;
        }

    }
}
