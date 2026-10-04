using System;
using UnityEngine;
using UnityEngine.UIElements;

public class HealthBarUI : MonoBehaviour, IUpdateable
{
    public playerHealth playerHealth;

    private VisualElement healthBar;

    public float fullHealthWidth = 500f;

    private void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        healthBar = root.Q<VisualElement>("HealthBar");

        UpdateHealthBar();
    }

    private void OnEnable()
    {
        GameUpdateManager.Instance.Register(this, UpdatePriority.High);

    }
    private void OnDisable()
    {
        GameUpdateManager.Instance.Unregister(this);

    }

    public void OnUpdate(float deltaTime) {

        UpdateHealthBar();
    }



    public void UpdateHealthBar()
    {
    

        float healthPercent = (float)playerHealth.health/ playerHealth.MaxHealth;

        float newWidth = healthPercent * fullHealthWidth;
        healthBar.style.width = new Length(newWidth, LengthUnit.Pixel);
    }

    private void Reset()
    {
        playerHealth.health = playerHealth.MaxHealth;
        UpdateHealthBar();
    }
}