using TMPro;
using UnityEngine;

public class FPS : MonoBehaviour
{
    public float deltaTime = 0.0f;
    public TextMeshProUGUI TextFPS;
    private float fps;

    void Start()
    {
        InvokeRepeating(nameof(UpdateFPS), 0, 1f);
    }
    void Update()
    {
    
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        fps = 1.0f / deltaTime;
        
    }
    void UpdateFPS()
    {
        TextFPS.text = $"FPS: {Mathf.Ceil(fps)}";
    }
    
}
