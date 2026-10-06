using UnityEngine;
using UnityEngine.Rendering;

public class EnemyStats : MonoBehaviour
{
    public float Speed = 0f;
    public float MaxHealth = 10f;
    public float Damage = 1.5f;


    public float BatSpeed = 0f;

    public float BatMaxHealth = 10f;

    public float BatDamage = 3.5f;


    public void ApplyScaling(float speed, float health, float damage)
    {
        Speed *= speed;
        MaxHealth *= health;
        Damage *= damage;
        BatSpeed *= speed;
        BatMaxHealth *= health;
        BatDamage *= damage;
    }

}
