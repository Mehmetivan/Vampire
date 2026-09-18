using UnityEngine;

public class enemyDamage : MonoBehaviour

{

    //public playerHealth playerHealth;
    public int damage = 2;

    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();

        if (damageable != null)
        {
            damageable.TakeDamage(damage);
        }
    }

}
