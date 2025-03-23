using UnityEngine;

public class MuiTen_MuaTen : MonoBehaviour
{
    private int damage = 5;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
            
            IDamageable damageable = other.gameObject.GetComponent<IDamageable>();
            if (damageable != null)
            {

                damageable.TakeDamage(damage);
            }

        }
        
    }
}
