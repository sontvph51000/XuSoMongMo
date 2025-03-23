using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Create_Ice : MonoBehaviour
{
    public GameObject icePrefab; 
    public float radius = 1f;
    public int iceCount = 36;
    public float speed = 10f;
    public List<GameObject> ListIce;
    public bool daChon = false;
    public Transform spawnPoint;
    public GameObject LockSkill;
    public GameObject DaChon;
    public TextMeshProUGUI text;
    void Start()
    {
        
        for (int i = 0; i < iceCount; i++)
        {
            GameObject ice = Instantiate(icePrefab, transform);
            ListIce.Add(ice);
            ice.SetActive(false);
        }
    }

    void Update()
    {
        if (daChon && Input.GetKeyDown(KeyCode.Space))
        {
            spawnPoint = GameObject.FindGameObjectWithTag("Player").transform;
            ShootArrows(spawnPoint);
            DaChon.SetActive(false);
            text.text = "";
            LockSkill.SetActive(true);
        }
    }

    public void KichHoat()
    {
        daChon = true;
        text.text = "Press 'SPACE' to activate skill";
    }
    public void ShootArrows(Transform spawnPoint)
    {
        for (int i = 0; i < iceCount; i++)
        {
            float angle = i * (360f / iceCount); 
            Quaternion rotation = Quaternion.Euler(0, 0, angle); 
            Vector3 spawnPos = spawnPoint.position + (Vector3)(rotation * Vector3.up * radius); 
            var get = ListIce.FirstOrDefault(x => !x.gameObject.activeSelf);
            if (get != null)
            {
                get.transform.position = spawnPos;
                get.transform.rotation = rotation;
                get.SetActive(true); 
                get.GetComponent<Ice_Skill_SlowIce>().SetVelocity(speed);
                daChon = false;
                
            }
        }
    }
}


 

