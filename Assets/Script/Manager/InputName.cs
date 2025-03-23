using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InputSinhVien : MonoBehaviour
{
    public TMP_InputField inputName;
    public TextMeshProUGUI thongBao;
    public GameObject inPutName;
    public int diemCao;
    public TextMeshProUGUI UIdiem;
    public TextMeshProUGUI Name;
    public GameObject DiemCaoGameObject;
    
    public TextMeshProUGUI Diem;

    void Start()
    {
        Time.timeScale = 0;
    }

    void Update()
    {
        CongDiemCao();
    }
    public void addPlayer()
    {
        Name.text = inputName.text;
        GameManager.gameManager.AddNamePlayer(inputName,thongBao,inPutName);
        CongDiemCao();
    }

    public void AddDiemCao()
    {
        GameManager.gameManager.AddScorePlayer(GameManager.gameManager.SinhVienHientai.id,UIdiem,DiemCaoGameObject);
    }

    public void CongDiemCao()
    {
        Diem.text = $"Point: {GameManager.gameManager.DiemSoHienTai}";
        
    }
    
    public void NewGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Home");
    }
}
