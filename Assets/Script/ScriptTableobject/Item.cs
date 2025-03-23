using UnityEngine;

public enum ItemType
{
    HoiHP,HoiMP
}
[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Item")]
public class Item : ScriptableObject
{
    public int id;
    public string itemName;
    public int value;
    public Sprite sprite;
    public int itemQuantity;
    public string itemInfor;
    public ItemType itemType;
    public AnimatorOverrideController itemAnimator;
}
