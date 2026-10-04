using UnityEngine;

public class enemyDamage : MonoBehaviour

{

    //public playerHealth playerHealth;
    public float damage = 2f;

    
    void Start()
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
