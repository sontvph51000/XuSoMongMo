using UnityEngine;

public class Skill_SlowIce : MonoBehaviour
{
    public Transform target; // Nhân vật làm tâm quỹ đạo
    public float a = 3f; // Bán kính theo trục X
    public float b = 2f; // Bán kính theo trục Y
    public float speed = 2f; // Tốc độ quay

    private float angle = 0f; // Góc hiện tại

    void Update()
    {
        if (target == null) return;

        // Tăng góc quay theo thời gian
        angle += speed * Time.deltaTime;
        if (angle > 2 * Mathf.PI) angle -= 2 * Mathf.PI;

        // Tính vị trí theo hình elip
        float x = target.position.x + a * Mathf.Cos(angle);
        float y = target.position.y + b * Mathf.Sin(angle);

        // Cập nhật vị trí cho game object
        transform.position = new Vector2(x, y);
    }
}
