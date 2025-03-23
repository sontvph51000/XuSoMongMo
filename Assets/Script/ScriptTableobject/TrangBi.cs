using UnityEngine;
public enum TrangBiType
{
    Mu,
    GiapVai,
    Ao,
    Quan,
    Giay,
    VuKhi,
}
[CreateAssetMenu(fileName = "TrangBi", menuName = "Scriptable Objects/TrangBi")]

public class TrangBi : ScriptableObject
{
    public int TrangBi_ID;
    public string TrangBi_Name;
    public Sprite TrangBi_Sprite;
    public string TrangBi_Infor;
    public TrangBiType TrangBi_Type;
    public AnimatorOverrideController TrangBi_Animator;
    public float TiLeRa;
}
