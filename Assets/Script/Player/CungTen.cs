using UnityEngine;

public class CungTen : MonoBehaviour
{
    public CreateMuiTen createMuiTen;
    public Vector2 mousePosition;
    public AudioSource audio;
    public AudioClip clip;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
        }
    }
    public void BanTen()
    {
        createMuiTen.BanTen(mousePosition);
    }

    public void SoundBanTen()
    {
        audio.PlayOneShot(clip);
    }
}
