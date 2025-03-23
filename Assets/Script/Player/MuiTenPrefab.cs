using UnityEngine;

public class MuiTenPrefab : MonoBehaviour
{
    public ScriptableObject_Player playerScript;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
            
            IDamageable damageable = other.gameObject.GetComponent<IDamageable>();
            if (damageable != null)
            {

                damageable.TakeDamage(playerScript.Damage);
            }
            gameObject.SetActive(false);
        }
        if (other.CompareTag("RaoChan"))
        {

            gameObject.SetActive(false);
            
        }
    }
}
