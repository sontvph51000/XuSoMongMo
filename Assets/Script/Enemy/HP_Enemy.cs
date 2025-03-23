using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HP_Enemy : MonoBehaviour, IDamageable
{
    public bool isDead = false;
    public int maxHealth;
    public int currentHealth;
    public Slider healthSlider;
    
    private IDamageable _damageable;
    public SpriteRenderer spriteRenderer;
    private Color _originalColor;
    private float _flashDuration = 0.1f;
    
    public Animator animator;
    public TextMeshProUGUI healthText;
    
    public int diem;
    void Start()
    {
        
    }

    public void MaxHP()
    {
        isDead = false;
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
        _originalColor = spriteRenderer.color;
        healthText.text = $"{currentHealth}/{maxHealth}";
    }
    public void TakeDamage(int damage)
    {
        if (!isDead )
        {
            currentHealth -= damage;
            StartCoroutine(FlashRoutine());
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); 

            UpdateHealthUI();

            if (currentHealth <= 0)
            {
                isDead = true;
                animator.SetTrigger("DieTriger");
                CongDiem();
                StartCoroutine(DeathRoutine());
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
    IEnumerator FlashRoutine()
    {
        spriteRenderer.color = new Color(1,0.7f,0.7f);  
        yield return new WaitForSeconds(_flashDuration);
        spriteRenderer.color = _originalColor; 
    }

    IEnumerator DeathRoutine()
    {
        yield return new WaitForSeconds(.4f);
        gameObject.SetActive(false);
    }
    public void CongDiem()
    {
        GameManager.gameManager.DiemSoHienTai += diem;
    }
}

