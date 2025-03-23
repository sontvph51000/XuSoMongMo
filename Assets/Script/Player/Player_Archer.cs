using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player_Archer : Player, IDamageable
{
  
    [SerializeField] TrangBi muTrumDau;
    [SerializeField] TrangBi muToc;
    
    private IDamageable damageable;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (rb.linearVelocity == Vector2.zero)
            {
                Atk(mousePosition);
            }
        }
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     
        //     ChangeOutfit(muTrumDau.TrangBi_Animator);
        // }

        // if (Input.GetKeyDown(KeyCode.G))
        // {
        //     ChangeOutfit(muToc.TrangBi_Animator);
        // }
        if (!attacking)
        {
            Move();
            Animation_TrangBi(aniAoLot);
            Animation_TrangBi(aniMu);
            Animation_TrangBi(aniAo);
            Animation_TrangBi(aniQuan);
            Animation_TrangBi(aniVuKhi);
            Animation_TrangBi(aniGiay);
        }
        
        
        
        
        
        
    }
    public void ChangeOutfit( AnimatorOverrideController overrideController )
    {
        if (aniMu != null && overrideController != null)
        {
            aniMu.runtimeAnimatorController = overrideController;
        }
    }
    
    
    
    
}
