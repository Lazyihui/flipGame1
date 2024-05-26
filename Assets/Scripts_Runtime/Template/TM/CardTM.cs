using System;
using UnityEngine;


[CreateAssetMenu(fileName = "TM_Card", menuName = "Template/CardTM")]
public class CardTM : ScriptableObject {
    [Header("Card")]

    public int id;

    public int type;

    public string typeName;

    
    public Material material;


}