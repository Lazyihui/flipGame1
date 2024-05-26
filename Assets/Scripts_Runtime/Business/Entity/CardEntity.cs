using System;
using UnityEngine;


public class CardEntity : MonoBehaviour {


    [SerializeField] MeshRenderer meshRenderer;

    public int id;

    public int type;

    public string typeName;

    public CardFSMStatus cardFSMStatus;

    public bool Idle_Entering;

    public bool Rotate_Entering;
    // maintain
    public float Rotation_maintainTime;

    public float Rotation_maintainInterval;

    public void  Ctor() { }

    public void SetMaterial(Material material) {
        meshRenderer.material = material;
    }

    public void SetPosition(Vector3 position) {
        transform.position = position;
    }

    public void Enter_Idle() {
        cardFSMStatus = CardFSMStatus.Idle;
        Idle_Entering = true;
    }

    public void Enter_Rotate() {
        cardFSMStatus = CardFSMStatus.Rotate;
        Rotate_Entering = true;
    }

}