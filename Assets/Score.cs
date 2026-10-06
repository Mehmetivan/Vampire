using UnityEngine;
using UnityEngine.UIElements;

public class Score : MonoBehaviour, IUpdateable
{
    public UIDocument uiDocument;

    private Label score;
    private float scoreValue = 0;

    void Start()
    {
        VisualElement root = uiDocument.rootVisualElement;
        score = root.Q<Label>("Score");
    }

    public void OnUpdate(float deltaTime)
    {
        scoreValue += deltaTime;
        score.text = scoreValue.ToString("0");
        if (scoreValue > PlayerPrefs.GetFloat("HighScore", 0f)) {
            PlayerPrefs.SetFloat("HighScore", scoreValue);

        }
           
    }

    private void OnEnable()
    {
        GameUpdateManager.Instance.Register(this, UpdatePriority.High);

    }
    private void OnDisable()
    {
        GameUpdateManager.Instance.Unregister(this);

    }


}