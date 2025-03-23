using UnityEngine;

public class Enemy_GiunDat : Enemy
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player= GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            KiemTraPlayer();
            
        }
    }
}
