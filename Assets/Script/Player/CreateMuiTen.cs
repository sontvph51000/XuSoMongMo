using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class CreateMuiTen : MonoBehaviour
{


    public GameObject MuiTenFrefab;
    public List<GameObject> ListMuiTen;
    public List<GameObject> ListMuiTenFront;
    public int MuiTenCount = 10;
    public int MuiTenFrontCount = 10;
    public Transform transformParent;
    void Start()
    {
        for (int i = 0; i < MuiTenCount; i++)
        {
            GameObject MuiTen = Instantiate(MuiTenFrefab, transform);
            ListMuiTen.Add(MuiTen);
            MuiTen.SetActive(false);
        }
        
    }
    

    public void BanTen(Vector2 targetPosition)
    {
        var get = ListMuiTen.FirstOrDefault(x => !x.gameObject.activeSelf);
        if (get != null)
        {
            get.transform.SetParent(transform); 
            get.transform.position = transform.position; 
            get.gameObject.SetActive(true);
            Vector2 direction = (targetPosition - (Vector2)get.transform.position).normalized;
            
            get.transform.SetParent(transformParent);
        
            // Xoay mũi tên theo hướng bắn
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            get.transform.rotation = Quaternion.Euler(0, 0, angle);
        
            // Gán vận tốc cho mũi tên
            Rigidbody2D rb = get.GetComponent<Rigidbody2D>();
            rb.linearVelocity = direction * 10f;

        }
    }
    
    
}
