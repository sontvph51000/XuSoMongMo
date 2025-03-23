using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObject_Player", menuName = "Scriptable Objects/ScriptableObject_Player")]
public class ScriptableObject_Player : ScriptableObject
{
    public int Damage;
    public int MaxHealth;
    public int Speed;
    public Animator AnimatorMu;
    public Animator AnimatorAo;
    public Animator AnimatorQuan;
    public Animator AnimatorGiay;
}
