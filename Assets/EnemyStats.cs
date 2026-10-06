using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float Speed = 0f;
    public float MaxHealth = 10f;
    public float Damage = 3f;


    public void ApplyScaling(float speed, float health, float damage)
    {
        Speed *= speed;
        MaxHealth *= health;
        Damage *= damage;
    }

}
