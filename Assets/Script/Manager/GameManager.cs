using System.Linq;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager{get; private set;}
    
    public ScriptableObject_TTSV scriptableObject_TTSV;

    public ThongTinSinhVien SinhVienHientai;

    public int DiemSoHienTai;
    private void Awake()
    {
        if (gameManager != null || gameManager != this)
        {
            Destroy(gameManager);
        }
        gameManager = this;
        
    }

    public void LoadNameTop10SV(TextMeshProUGUI textNameTop10SV)
    {
        textNameTop10SV.text = "";
        var top10Players = scriptableObject_TTSV.List_SV
            .OrderByDescending(p => p.diemCao)
            .Take(10) 
            .ToList();
        foreach (var player in top10Players)
        {
            textNameTop10SV.text += $"{player.name}\n";
        }
    }
    public void LoadScore10SV(TextMeshProUGUI textDiemTop10SV)
    {
        textDiemTop10SV.text = "";
        var top10Players = scriptableObject_TTSV.List_SV
            .OrderByDescending(p => p.diemCao)
            .Take(10) 
            .ToList();
        foreach (var player in top10Players)
        {
            textDiemTop10SV.text += $"{player.diemCao}\n";
        }
    }
    
    public void AddNamePlayer(TMP_InputField inputName,TextMeshProUGUI thongBao, GameObject gameObjectName)
    {
        
        if (string.IsNullOrEmpty(inputName.text))
        {
            thongBao.text = "Your name is invalid - Please re-enter";
            return;
        }
        bool isDuplicate = scriptableObject_TTSV.List_SV.Any(p => p.name == inputName.text);
        if (isDuplicate)
        {
            thongBao.text = "Name already exists";
            return;
        }
        else
        {
            
            int idHientai = 0;
            if (scriptableObject_TTSV.List_SV.Count > 0)
            {
                idHientai = scriptableObject_TTSV.List_SV.Max(p => p.id) + 1;
                
            }

            SinhVienHientai = new ThongTinSinhVien { id = idHientai, name = inputName.text };
            scriptableObject_TTSV.List_SV.Add(SinhVienHientai);
            DiemSoHienTai = 0;
            thongBao.text = "";
            inputName.text = "";
            gameObjectName.SetActive(false);
            Time.timeScale = 1;
            
        }
        
        
    }
    public void AddScorePlayer(int ID, TextMeshProUGUI thongBao, GameObject gameObjectScore)
    {
        
        ThongTinSinhVien sinhVien = scriptableObject_TTSV.List_SV.FirstOrDefault(p => p.id == ID);
        if (sinhVien != null)
        {
            sinhVien.diemCao = DiemSoHienTai; 
        }
        thongBao.text = $"ID: {sinhVien.id}\n  Name: {sinhVien.name}\n  Score: {DiemSoHienTai}";
        gameObjectScore.SetActive(true);
        
    }

    public ThongTinSinhVien GetID()
    {
        return GetID();
    }
    
    
    
    
    public void ExitGame()
    {
        Application.Quit();
    }
    public void NewGame()
    {
        SceneManager.LoadScene("Play");
    }
   
}
