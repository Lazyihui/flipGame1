using System;
using UnityEngine;


public class CardEntity : MonoBehaviour {


    [SerializeField] MeshRenderer meshRenderer;

    public int id;

    public int type;

    public string typeName;

    public void Ctor() { }

    public void SetMaterial(Material material) {
        meshRenderer.material = material;
    }


}