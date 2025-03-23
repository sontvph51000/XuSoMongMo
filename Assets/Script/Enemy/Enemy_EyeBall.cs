using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy_EyeBall : Enemy
{
    public Transform ViTriAtk;
    public Transform lazeEnemy;
    
    public List<GameObject> ListLazerRight ;
    public List<GameObject> ListLazerLeft ;
    public List<GameObject> ListLazerBack;
    public List<GameObject> ListLazerFront;
    public int LazerRight = 10;
    public int LazerLeft = 10;
    public int LazerBack = 10;
    public int LazerFront = 10;
    public GameObject LazerRightPrefab;
    public GameObject LazerLeftPrefab;
    public GameObject LazerBackPrefab;
    public GameObject LazerFrontPrefab;
    
    public AudioSource audio;
    public AudioClip clip;
    void Start()
    {
        player= GameObject.FindGameObjectWithTag("Player").transform;
        
        for (int i = 0; i < LazerRight; i++)
        {
            GameObject lazerRight = Instantiate(LazerRightPrefab, ViTriAtk);
            ListLazerRight.Add(lazerRight);
            lazerRight.SetActive(false);
        }
        for (int i = 0; i < LazerLeft; i++)
        {
            GameObject lazerLeft = Instantiate(LazerLeftPrefab, ViTriAtk);
            ListLazerLeft.Add(lazerLeft);
            lazerLeft.SetActive(false);
        }
        for (int i = 0; i < LazerBack; i++)
        {
            GameObject lazerBack = Instantiate(LazerBackPrefab, ViTriAtk);
            ListLazerBack.Add(lazerBack);
            lazerBack.SetActive(false);
        }
        for (int i = 0; i < LazerFront; i++)
        {
            GameObject lazeFront = Instantiate(LazerFrontPrefab, ViTriAtk);
            ListLazerFront.Add(lazeFront);
            lazeFront.SetActive(false);
        }
        
    }
    
    void Update()
    {
        KiemTraPlayer();
        
        
    }

    
    public void Atk(GameObject bullet)
    {
        GameObject laze = Instantiate(bullet, ViTriAtk.position, transform.rotation);
        laze.transform.parent = ViTriAtk;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (angle > 0)
        {
            angle += 180;
        }
        laze.transform.rotation = Quaternion.Euler(0, 0, angle);
        
        // Gán vận tốc cho mũi tên
        Rigidbody2D rb = laze.GetComponent<Rigidbody2D>();
        rb.linearVelocity = direction * 10f;
    }

    public void AtkRight()
    {
        if(player==null || player.gameObject.GetComponent<Player>().isDead) return;
        var get = ListLazerRight.FirstOrDefault(x => !x.gameObject.activeSelf);
        if (get != null)
        {
            get.transform.SetParent(ViTriAtk); 
            get.transform.position = ViTriAtk.position; 
            
            get.transform.SetParent(lazeEnemy);
            get.gameObject.SetActive(true);
        
            // Xoay mũi tên theo hướng bắn
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            get.transform.rotation = Quaternion.Euler(0, 0, angle);
        
            // Gán vận tốc cho mũi tên
            Rigidbody2D rb = get.GetComponent<Rigidbody2D>();
            rb.linearVelocity = direction * 10f;
            
        }
    }
    public void AtkLeft()
    {
        if(player==null || player.gameObject.GetComponent<Player>().isDead) return;
        var get = ListLazerLeft.FirstOrDefault(x => !x.gameObject.activeSelf);
        if (get != null)
        {
            get.transform.SetParent(ViTriAtk); 
            get.transform.position = ViTriAtk.position; 
            get.gameObject.SetActive(true);
            
            get.transform.SetParent(lazeEnemy);
        
            // Xoay mũi tên theo hướng bắn
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            if (angle > 0) angle -= 180;
            else if (angle < 0) angle += 180;
            get.transform.rotation = Quaternion.Euler(0, 0, angle);
        
            // Gán vận tốc cho mũi tên
            Rigidbody2D rb = get.GetComponent<Rigidbody2D>();
            rb.linearVelocity = direction * 10f;
           
        }
    }
    public void AtkBack()
    {
        if(player==null || player.gameObject.GetComponent<Player>().isDead) return;
        var get = ListLazerBack.FirstOrDefault(x => !x.gameObject.activeSelf);
        if (get != null)
        {
            get.transform.SetParent(ViTriAtk); 
            get.transform.position = ViTriAtk.position; 
            get.gameObject.SetActive(true);
            
            get.transform.SetParent(lazeEnemy);
        
            // Xoay mũi tên theo hướng bắn
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            if (angle > 0) angle -= 90;
            else if (angle < 0) angle += 90;
            get.transform.rotation = Quaternion.Euler(0, 0, angle);
        
            // Gán vận tốc cho mũi tên
            Rigidbody2D rb = get.GetComponent<Rigidbody2D>();
            rb.linearVelocity = direction * 10f;
           
        }
    }
    public void AtkFront()
    {
        if(player==null || player.gameObject.GetComponent<Player>().isDead) return;
        var get = ListLazerFront.FirstOrDefault(x => !x.gameObject.activeSelf);
        if (get != null)
        {
            get.transform.SetParent(ViTriAtk); 
            get.transform.position = ViTriAtk.position; 
            get.gameObject.SetActive(true);
            
            get.transform.SetParent(lazeEnemy);
        
            // Xoay mũi tên theo hướng bắn
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            get.transform.rotation = Quaternion.Euler(0, 0, angle);
        
            // Gán vận tốc cho mũi tên
            Rigidbody2D rb = get.GetComponent<Rigidbody2D>();
            rb.linearVelocity = direction * 10f;
            
        }
    }

    public void SoundBanDan()
    {
        audio.PlayOneShot(clip);
    }
 
}
