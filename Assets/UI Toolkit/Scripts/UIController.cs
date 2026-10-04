using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour

{

    public static UIController Instance;
    [SerializeField] private UIDocument uiDocument;

    private VisualElement pauseOverlayBackground;
    private VisualElement pauseOverlayMenu;
    private VisualElement startOverlayBackground;
    private VisualElement startOverlayMenu;

    private VisualElement endOverlayBackground;

    private VisualElement endOverlayMenu;

    private VisualElement loseOverlayBackground;
    private VisualElement loseOverlayMenu;

    private Button pauseButton;
    private Button resumeButton;

    private Button playButton;

    private Button StartOptionsButton;

    private Button PauseOptionsButton;

    private VisualElement optionsOverlay;
    private Button ExitOptionsButton;

    private Button restartButton;

    private VisualElement UpgradeMenu;
    private VisualElement UpgradeBackground;

    private ProgressBar progressBar;

    private Button SpeedUpgrade;
    private Button HealthUpgrade;
    private Button DamageUpgrade;       


    void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        VisualElement root = uiDocument.rootVisualElement;

        pauseOverlayBackground = root.Q<VisualElement>("Pause");
        pauseOverlayMenu = root.Q<VisualElement>("PauseMenu");

        startOverlayBackground = root.Q<VisualElement>("Start");
        startOverlayMenu = root.Q<VisualElement>("StartMenu");

        pauseButton = root.Q<Button>("PauseButton");
        resumeButton = root.Q<Button>("ResumeButton");

        playButton = root.Q<Button>("PlayButton");

        restartButton = root.Q<Button>("RestartButton");



        StartOptionsButton = root.Q<Button>("StartOptionsButton");

        PauseOptionsButton = root.Q<Button>("PauseOptionsButton");

        ExitOptionsButton = root.Q<Button>("ExitOptionsButton");

        optionsOverlay = root.Q<VisualElement>("Options");

        optionsOverlay.style.display = DisplayStyle.None;


        loseOverlayBackground = root.Q<VisualElement>("GameOver");
        loseOverlayMenu = root.Q<VisualElement>("GameOverMenu");

        loseOverlayBackground.style.display = DisplayStyle.None;
        loseOverlayMenu.style.display = DisplayStyle.None;

        // Hide the pause menu when the game starts
        pauseOverlayBackground.style.display = DisplayStyle.None;


        // Tell the buttons what to do when clicked
        pauseButton.clicked += OnPauseClicked;
        resumeButton.clicked += OnResumeClicked;

        playButton.clicked += OnPlayClicked;

        StartOptionsButton.clicked += OnStartOptionsClicked;
        PauseOptionsButton.clicked += OnPauseOptionsClicked;
        ExitOptionsButton.clicked += OnExitOptionsClicked;

        restartButton.clicked += OnRestartButtonClicked;


        UpgradeBackground = root.Q<VisualElement>("Upgrade");
        UpgradeMenu = root.Q<VisualElement>("UpgradeMenu");
        progressBar = root.Q<ProgressBar>("ProgressBar");

        UpgradeMenu.style.display = DisplayStyle.None;
        UpgradeBackground.style.display = DisplayStyle.None;

        SpeedUpgrade = root.Q<Button>("SpeedUpgrade");
        HealthUpgrade = root.Q<Button>("HealthUpgrade");
        DamageUpgrade = root.Q<Button>("DamageUpgrade");


        SpeedUpgrade.clicked += () => UpgradeManager.Instance.Choose(UpgradeType.Speed);
        HealthUpgrade.clicked += () => UpgradeManager.Instance.Choose(UpgradeType.Health);
        DamageUpgrade.clicked += () => UpgradeManager.Instance.Choose(UpgradeType.Damage);

    }

    public void OnPlayClicked()
    {
        Debug.Log("PLAY BUTTON CLICKED!");
        GameManager.Instance.ResumeGame();
        startOverlayBackground.style.display = DisplayStyle.None;

    }


    public void OnPauseClicked()
    {
        Debug.Log("PAUSE BUTTON CLICKED!");

        GameManager.Instance.PauseGame();

        pauseOverlayBackground.style.display = DisplayStyle.Flex;
    }

    public void OnResumeClicked()
    {
        Debug.Log("RESUME BUTTON CLICKED!");

        GameManager.Instance.ResumeGame();

        pauseOverlayBackground.style.display = DisplayStyle.None;
    }

    public void OnStartOptionsClicked()
    {
        Debug.Log("START OPTIONS BUTTON CLICKED!");
        optionsOverlay.style.display = DisplayStyle.Flex;

    }

    public void OnPauseOptionsClicked()
    {
        Debug.Log("PAUSE OPTIONS BUTTON CLICKED!");
        optionsOverlay.style.display = DisplayStyle.Flex;
    }

    public void OnExitOptionsClicked()
    {
        Debug.Log("EXIT OPTIONS BUTTON CLICKED!");
        optionsOverlay.style.display = DisplayStyle.None;
    }

    public void OnLoseGame()
    {
        Debug.Log("LOSE GAME!");
        loseOverlayBackground.style.display = DisplayStyle.Flex;
        loseOverlayMenu.style.display = DisplayStyle.Flex;
    }

    public void OnRestartButtonClicked()
    {
        Debug.Log("RESTART BUTTON CLICKED!");
        GameManager.Instance.RestartGame();
    }
    public void ShowUpgradeMenu()
    {
        UpgradeBackground.style.display = DisplayStyle.Flex;
        UpgradeMenu.style.display = DisplayStyle.Flex;
    }

    public void HideUpgradeMenu()
    {
        UpgradeBackground.style.display = DisplayStyle.None;
        UpgradeMenu.style.display = DisplayStyle.None;
    }

    public void SetUpgradeProgress(float value01)
    {
        if (progressBar != null) progressBar.value = value01 * 100f; // ProgressBar defaults to 0-100
    }





}