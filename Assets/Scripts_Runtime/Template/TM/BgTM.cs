using System;
using UnityEngine;


[CreateAssetMenu(fileName = "TM_Bg", menuName = "Template/BgTM")]
public class BgTM : ScriptableObject {

    [Header("BgTM")]
    public int id;
    public Material material;


}