using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class KichHoat_MuaTen : MonoBehaviour
{
    public bool lockSkill = false;
    public Texture2D skillCursor; 
    public Texture2D defaultCursor ; 
    public bool isSkillActive = false; 
    public GameObject Img_click;
    public GameObject Img_LockSkill;

    public GameObject SkillMuaTen;
    public GameObject SkillMuaTenPrefab;
    
    public TextMeshProUGUI SkillText;
    void Start()
    {
        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
    
        SkillMuaTen = Instantiate(SkillMuaTenPrefab, transform);
        SkillMuaTen.GetComponent<Skill_MuaTen>().SpawnMuaTen();
        SkillMuaTen.SetActive(false);
    }

    private void Update()
    {
        HandleMouseClick();
    }

    public void UnLockSkill()
    {
        lockSkill = false;
        Img_LockSkill.SetActive(false);
    }
    public void KichHoat()
    {
        isSkillActive = true;
        SkillText.text = "Left click to activate skill";
        Cursor.SetCursor(skillCursor, Vector2.zero, CursorMode.Auto);
    }
    void HandleMouseClick()
    {
        if (isSkillActive && Input.GetMouseButtonDown(0)) 
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            UseSkill(mousePosition);
        }
    }

    void DeactivateSkill()
    {
        Img_click.gameObject.SetActive(false);
        SkillText.text = "";
        Img_LockSkill.gameObject.SetActive(true);
        lockSkill = true;
        isSkillActive = false;
        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto); 
    }

    void UseSkill(Vector2 position)
    {
        SkillMuaTen.SetActive(true);
         SkillMuaTen.transform.position = position;
         SkillMuaTen.GetComponent<Skill_MuaTen>().StartSpawn();
         DeactivateSkill();
        
    }

 
    
}