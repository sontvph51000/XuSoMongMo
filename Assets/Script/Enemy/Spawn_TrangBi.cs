using UnityEngine;

public class Spawn_TrangBi : MonoBehaviour
{
    public TrangBi TrangBi;

    public void SetItem(TrangBi newTrangBi)
    {
        TrangBi = newTrangBi;
        GetComponent<SpriteRenderer>().sprite = newTrangBi.TrangBi_Sprite;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            other.GetComponent<Player>().ChangeTrangBi(TrangBi);
            Destroy(gameObject);
        }
    }
}
