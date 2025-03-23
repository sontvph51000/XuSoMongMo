using UnityEngine;

public class Enemy_Spider : MonoBehaviour
{
    public float speed = 2f; // Tốc độ di chuyển
    public float detectionRange = 0.5f; 
    public Transform player;
    public Vector2 direction;
    public Animator animator;
    public Rigidbody2D rb;
    void Start()
    {
        player= GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null) return;

        
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer > detectionRange)
        {
            animator.SetBool("Atk", false);
            MoveTowardsPlayer();
        }
        else
        {
            rb.linearVelocity = Vector2.zero; 
            animator.SetBool("Atk", true);
            Atk();
        }
    }
    
    void MoveTowardsPlayer()
    {
        
        direction = (player.position - transform.position).normalized;
        
        rb.linearVelocity = direction * speed * Time.deltaTime;

        
        if (direction != Vector2.zero)
        {
            if (direction.x > 0.5f)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                animator.SetFloat("DirX",1);
            }
                
            else if (direction.x < -0.5f)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
                animator.SetFloat("DirX",-1);
            }
            else
            {
                animator.SetFloat("DirX",0);
            }
            
        }
        else
        {
            if (direction.y > 0.5f)
                animator.SetFloat("DirY", 1);
            else if (direction.y < -0.5f)
                animator.SetFloat("DirY",-1);
            else
            {
                animator.SetFloat("DirY",0);
            }
        }
    }

    void Atk()
    {
        if (direction.magnitude == 0)
        {
            if (direction.x > 0.5f)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                animator.SetFloat("SttX",1);
            }
                
            else if (direction.x < -0.5f)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
                animator.SetFloat("SttX",-1);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                animator.SetFloat("SttX",0);
            }
            
        }
        else
        {
            if (direction.y > 0.5f)
                animator.SetFloat("SttY", 1);
            else if (direction.y < -0.5f)
                animator.SetFloat("SttY",-1);
            else
            {
                animator.SetFloat("SttY",0);
            }
        }
    }

    
}
