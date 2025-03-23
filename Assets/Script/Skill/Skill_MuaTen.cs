using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;

public class Skill_MuaTen : MonoBehaviour
{
    public GameObject objectToSpawn; // Prefab cần spawn
    public Vector2 ellipseCenter ; // Tâm hình elip
    public float xRadius = 2.5f; // Bán kính theo trục X
    public float yRadius = 1f; // Bán kính theo trục Y
    public int spawnCount = 150; // Số lượng object muốn spawn

    
    public GameObject MuaTenPrefab;

    void Start()
    {
        
        
    }

    public void SpawnMuaTen()
    {
        
    }
    public void StartSpawn()
    {
        gameObject.SetActive(true);
        ellipseCenter = gameObject.transform.position;
        StartCoroutine(Spawn());
        StartCoroutine(Spawn());
        StartCoroutine(Spawn());
    }
    Vector2 GetRandomPointInEllipse()
    {
        float angle = Random.Range(0f, 2f * Mathf.PI); // Góc ngẫu nhiên từ 0 đến 360 độ
        float radius = Mathf.Sqrt(Random.Range(0f, 1f)); // Tạo khoảng cách từ tâm (phân bố đồng đều)
        float x = ellipseCenter.x + radius * xRadius * Mathf.Cos(angle);
        float y = ellipseCenter.y + radius * yRadius * Mathf.Sin(angle);

        return new Vector2(x, y);
    }

    IEnumerator Spawn()
    {
        for (int i = 0; i <= spawnCount; i++)
        {
            
             Vector2 randomPosition = GetRandomPointInEllipse();
             GameObject muaTen = Instantiate(MuaTenPrefab, randomPosition, Quaternion.identity);
             muaTen.transform.position = randomPosition;
             Destroy(muaTen, 2);
             yield return new WaitForSeconds(0.2f);
       }
        gameObject.SetActive(false);
        
    }

    
}
