using System;
using UnityEngine;
using UnityEngine.UIElements;

public class HealthBarUI : MonoBehaviour
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

    private void Update()
    {
        UpdateHealthBar();

    }

    public void UpdateHealthBar()
    {
    

        float healthPercent = (float)playerHealth.health/ playerHealth.maxHealth;

        float newWidth = healthPercent * fullHealthWidth;
        healthBar.style.width = new Length(newWidth, LengthUnit.Pixel);
    }

    private void Reset()
    {
        playerHealth.health = playerHealth.maxHealth;
        UpdateHealthBar();
    }
}