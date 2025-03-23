using System;
using UnityEngine;

public class Atk_Player : MonoBehaviour
{
    
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
