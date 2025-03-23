using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed ; 
    public float detectionRange  ; 
    public SpriteRenderer spriteRenderer;
    public Transform player;
    public Vector2 direction;
    public Vector2 velocity;
    public Animator animator;
    public Rigidbody2D rb;

    
    // public List<TrangBi> possibleDrops; // Danh sách vật phẩm có thể rơi
    // public Transform dropPoint; // Vị trí rơi vật phẩm
    // public GameObject TrangBiPrefab;

    // void DropItem()
    // {
    //     float randomValue = Random.Range(0f, 100f);
    //     float cumulativeChance = 0f;
// 
    //     foreach (TrangBi trangBi in possibleDrops)
    //     {
    //         cumulativeChance += trangBi.TiLeRa;
    //         if (randomValue <= cumulativeChance)
    //         {
    //             GameObject droppedItem = Instantiate(TrangBiPrefab, dropPoint.position, Quaternion.identity);
    //             droppedItem.GetComponent<Spawn_TrangBi>().SetItem(trangBi);
    //             return;
    //         }
    //     }
    // }



    public void KiemTraPlayer()
    {
        if (player == null) return;
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        
        if (transform.position.y > player.position.y)
        {
            spriteRenderer.sortingLayerName = "Player";
        }
        else
        {
            spriteRenderer.sortingLayerName = "New Layer 7";
        }
        
        
        
        if (distanceToPlayer > detectionRange )
        {
            velocity = direction * speed * Time.deltaTime;
            animator.SetFloat("Atk", direction.magnitude);
            MoveTowardsPlayer();
            SetDirection();
        }
        else
        {
            rb.linearVelocity  = Vector2.zero; 
            animator.SetFloat("Atk", 0 );
            SetDirection();
            SetSttAtk();
        }
    }
    public void SetDirection()
    {
        Vector3 playerPosition = new Vector3(player.position.x, player.position.y - 0.5f, player.position.z);
        direction = (playerPosition - transform.position).normalized;
        
    }
    void MoveTowardsPlayer()
    {
        
        rb.linearVelocity  = velocity; 
        
        if (velocity != Vector2.zero)
        {
            
            if (direction.x > 0.4f) animator.SetFloat("DirX",1);
            else if (direction.x < -0.4f) animator.SetFloat("DirX",-1);
            else animator.SetFloat("DirX",0);
            
            if (direction.y > 0.4f)  animator.SetFloat("DirY", 1);
            else if (direction.y < -0.4f) animator.SetFloat("DirY",-1);
            else animator.SetFloat("DirY",0);
            
        }
    }

    void SetSttAtk()
    {
        if (direction.x > 0.7f) animator.SetFloat("SttX",1);
        else if (direction.x < -0.7f) animator.SetFloat("SttX",-1);
        else animator.SetFloat("SttX",0);
            
        if (direction.y > 0.7f)  animator.SetFloat("SttY", 1);
        else if (direction.y < -0.7f) animator.SetFloat("SttY",-1);
        else animator.SetFloat("SttY",0);
    }

    
}
