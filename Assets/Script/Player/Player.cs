using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Vector2 direction;
    public Vector2 idleDirection;
    public Vector2 atkDirection;
    public Rigidbody2D rb;
    public float inputHorizontal;
    public float inputVertical;
    public float speed;
    public Animator ani;
    private IDamageable _damageableImplementation;
    
    public Animator aniMu;
    public Animator aniAoLot;
    public Animator aniAo;
    public Animator aniQuan;
    public Animator aniGiay;
    public Animator aniVuKhi;

    public bool isDead = false;
    public int maxHealth;
    public int currentHealth;
    public Slider healthSlider;
    private IDamageable _damageable;
    public SpriteRenderer spriteRenderer;
    private Color _originalColor;
    private float _flashDuration = 0.1f;
    public AudioSource audioSource; 
    public AudioClip hurtSound;
    
    public TextMeshProUGUI healthText;
    
    public bool attacking = false;
    public ScriptableObject_Player playereScriptableObject;
    
    public InputSinhVien sinhVien;

    public List<AnimationClip> List_Clip = new List<AnimationClip>();
    void Start()
    {
        // foreach (var clip in List_Clip)
        // {
        //     clip.frameRate = 120;
        // }
        
        currentHealth = playereScriptableObject.MaxHealth;
        maxHealth = playereScriptableObject.MaxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
        UpdateHealthUI();
        
        _originalColor = spriteRenderer.color;
        
        speed = playereScriptableObject.Speed;
        
        playereScriptableObject.AnimatorMu = aniMu;
        playereScriptableObject.AnimatorAo = aniAo;
        playereScriptableObject.AnimatorQuan = aniQuan;
        playereScriptableObject.AnimatorGiay = aniGiay;
        
   
    }

    public void ChangeTrangBi( TrangBi trangBi )
    {
        switch (trangBi.TrangBi_Type)
        {
            case TrangBiType.Mu:
            {
                if (trangBi.TrangBi_Animator != null)
                {
                    aniMu.runtimeAnimatorController = trangBi.TrangBi_Animator;
                }
                return;
            }
            case TrangBiType.Ao:
            {
                if (aniAo != null && trangBi.TrangBi_Animator != null)
                {
                    aniAo.runtimeAnimatorController = trangBi.TrangBi_Animator;
                }
                return;
            }
            case TrangBiType.Quan:
            {
                if (aniQuan != null && trangBi.TrangBi_Animator != null)
                {
                    aniQuan.runtimeAnimatorController = trangBi.TrangBi_Animator;
                }
                return;
            }
            case TrangBiType.Giay:
            {
                if (aniGiay != null && trangBi.TrangBi_Animator != null)
                {
                    aniGiay.runtimeAnimatorController = trangBi.TrangBi_Animator;
                }
                return;
            }
        }
        
    }
 
    
    
    public void TruHp(int value)
    {
        // if (health >= 0)
        // {
        //     health -= value;
        // }
    }
    public void Move()
    {
        if (!attacking)
        {

            inputHorizontal = Input.GetAxisRaw("Horizontal");
            inputVertical = Input.GetAxisRaw("Vertical");
            direction = new Vector2(inputHorizontal, inputVertical);
            direction.Normalize();
            rb.linearVelocity = (direction * speed * Time.deltaTime);

            ani.SetFloat("Velocity", direction.magnitude);
            ani.SetFloat("RunX", direction.x);
            ani.SetFloat("RunY", direction.y);

            if (direction != Vector2.zero)
            {
                
                idleDirection = direction;
                
            }

            ani.SetFloat("IdleX", idleDirection.x);
            ani.SetFloat("IdleY", idleDirection.y);


        }
    }
    

    public void Animation_TrangBi(Animator animator)
    {
        animator.SetFloat("IdleX", idleDirection.x);
        animator.SetFloat("IdleY", idleDirection.y);
        animator.SetFloat("RunX", direction.x);
        animator.SetFloat("RunY", direction.y);
        animator.SetFloat("Velocity", direction.magnitude);
    }
  
    public void Atk(Vector3 atkDirection)
    {
        Vector2 directionMuiten = (atkDirection - transform.position).normalized;
        if (attacking) return;
        
        if (!attacking)
        {
            rb.linearVelocity = Vector2.zero;
            attacking = true;
            SetSttAtk(ani,directionMuiten);
            
            SetSttAtk(aniMu,directionMuiten);
            SetSttAtk(aniAoLot,directionMuiten);
            SetSttAtk(aniAo,directionMuiten);
            SetSttAtk(aniQuan,directionMuiten);
            SetSttAtk(aniGiay,directionMuiten);
            SetSttAtk(aniVuKhi,directionMuiten);
            StartCoroutine(DelayAtk( 0.9f));
        }
    }
    void SetSttAtk(Animator animator , Vector2 atkClick)
    {
        atkDirection = atkClick;
        idleDirection = Vector2Int.RoundToInt(atkClick);
        
        animator.SetFloat("IdleX", idleDirection.x);
        animator.SetFloat("IdleY", idleDirection.y);
        animator.SetTrigger("Atk");
        
    }
    
    
    IEnumerator DelayAtk( float delay)
    {
        
        yield return new WaitForSeconds(delay);
        attacking = false;
    }
    
    public void TakeDamage(int damage)
    {
        
        if(isDead) return;
        
        if (!isDead )
        {
            currentHealth -= damage;
            StartCoroutine(FlashRoutine());
            audioSource.PlayOneShot(hurtSound);
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); 

            UpdateHealthUI();

            if (currentHealth <= 0)
            {
                isDead = true;
                Die();
                
            }
        }
    }
    private void UpdateHealthUI()
    {
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
            healthText.text = $"{currentHealth}/{maxHealth}";
        }
    }

    private void Die()
    {
        
        ani.SetBool("Die",true);
        aniMu.SetBool("Die",true);
        aniAoLot.SetBool("Die",true);
        aniAo.SetBool("Die",true);
        aniQuan.SetBool("Die",true);
        aniGiay.SetBool("Die",true);
        
        StartCoroutine(DeadRoutine());

    }
    IEnumerator FlashRoutine()
    {
        spriteRenderer.color = new Color(1,0.8f,0.8f); // Chuyển màu 
        yield return new WaitForSeconds(_flashDuration);
        spriteRenderer.color = _originalColor; 
    }

    IEnumerator DeadRoutine()
    {
        yield return new WaitForSeconds(.5f);
        sinhVien.AddDiemCao();
        gameObject.SetActive(false);

    }


    
}
