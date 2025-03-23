using System.Collections;
using UnityEngine;

public class Ice_Skill_SlowIce : MonoBehaviour
{
    public Animator animator;
    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
            animator.SetTrigger("VaCham");

            // other.gameObject.GetComponent<Enemy>().speed *= 0.5f;
            // other.gameObject.GetComponent<Enemy>().spriteRenderer.color = Color.blue;
            // StartCoroutine(TroVeMacDinh());
            // other.gameObject.GetComponent<Enemy>().speed *= 2;
            // other.gameObject.GetComponent<Enemy>().spriteRenderer.color = Color.white;
        }
    }

    IEnumerator TroVeMacDinh()
    {
        yield return new WaitForSeconds(3f);
        
    }
    public void SetVelocity(float speed)
    {
        animator.SetTrigger("Atk");
        GetComponent<Rigidbody2D>().linearVelocity = transform.up * speed;
        StartCoroutine(SetActiveFalse());
    }
    public void SetFalseGameobject()
    {
        gameObject.SetActive(false);
    }

    IEnumerator SetActiveFalse()
    {
        yield return new WaitForSeconds(1.5f);
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
        
        
    }
}
