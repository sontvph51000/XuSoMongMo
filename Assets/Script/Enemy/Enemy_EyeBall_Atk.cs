using System.Collections;
using UnityEngine;

public class Enemy_EyeBall_Atk : MonoBehaviour
{

    private int damage = 2;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
            
            IDamageable damageable = other.gameObject.GetComponent<IDamageable>();
            if (damageable != null)
            {

                damageable.TakeDamage(damage);
            }
            gameObject.SetActive(false);
            
        }
        if (other.gameObject.CompareTag("RaoChan"))
        {

            gameObject.SetActive(false);
            
        }
        
        
    }

}
