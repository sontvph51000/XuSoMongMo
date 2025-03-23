using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject EyeBallPrefab;
    public List<GameObject> ListEyeBall;
    public int EyeBallCount = 10 ;
    float spawnTimerEyeBall = 7f;
    
    public GameObject GiunDatPrefab;
    public List<GameObject> ListGiunDat;
    public int giunDatCount = 20 ;
    float spawnTimerGiunDat = 3f;
    
    public GameObject GolemPrefab;

    public Transform center; // Tâm bản đồ
    public float spawnRadius ; // Bán kính spawn
    
    public InputSinhVien inputSinhVien ;
    public int diemCao = 0;
    void Start()
    {
        center = transform;
        for (int i = 0; i < giunDatCount; i++)
        {
            GameObject giun = Instantiate(GiunDatPrefab, transform);
            ListGiunDat.Add(giun);
            giun.SetActive(false);
        }

        for (int i = 0; i < EyeBallCount; i++)
        {
            GameObject ball = Instantiate(EyeBallPrefab, transform);
            ListEyeBall.Add(ball);
            ball.SetActive(false);
        }


        StartCoroutine(SpawnGiunDat(spawnTimerGiunDat, ListGiunDat));
        StartCoroutine(SpawnGiunDat(spawnTimerEyeBall, ListEyeBall));
        StartCoroutine(TruTG(spawnTimerGiunDat, 5f));
        StartCoroutine(TruTG(spawnTimerEyeBall, 5f));
        
    }



    IEnumerator SpawnGiunDat(float seconds, List<GameObject> list)
    {
        while (true)
        {
            var get = list.FirstOrDefault(x => !x.gameObject.activeSelf);
            if (get != null)
            {
                Vector2 spawnPosition = Random.insideUnitCircle.normalized * spawnRadius;
                Vector3 spawnPoint = new Vector3(spawnPosition.x, spawnPosition.y, 0) + center.position;
                
                get.transform.position = spawnPoint;
                get.GetComponent<HP_Enemy>().MaxHP();
                get.SetActive(true);
                get.GetComponent<Animator>().SetTrigger("XuatHien");
                
            }
            
            yield return new WaitForSeconds(seconds);
        }
        
    }


    IEnumerator TruTG(float tg, float waitForSeconds)
    {
        
        yield return new WaitForSeconds(waitForSeconds);
        if (tg > 1.1)
        {
            tg -= 0.5f;
        }
    }
}
