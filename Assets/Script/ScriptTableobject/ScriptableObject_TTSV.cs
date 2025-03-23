using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "ScriptableObject_TTSV", menuName = "Scriptable Objects/ScriptableObject_TTSV")]
public class ScriptableObject_TTSV : ScriptableObject
{
    public List<ThongTinSinhVien> List_SV = new List<ThongTinSinhVien>();
}
