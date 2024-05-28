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

    public bool ReRetate_Entering;

    public bool mouseEnter_Entering;

    public bool mouseExit_Entering;
    // maintain
    public float Rotation_maintainTime;

    public float Rotation_maintainInterval;

    public float MouseEnter_maintainTime;

    public float MouseEnter_maintainInterval;

    // 如果没有旋转则可以旋转 没有旋转才可以旋转
    public bool ishasRotate;
    public void Ctor() { }

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
    public void Enter_ReRetate() {
        cardFSMStatus = CardFSMStatus.ReRetate;
        ReRetate_Entering = true;
    }

    public void Enter_MouseEnter() {
        cardFSMStatus = CardFSMStatus.mouseEnter;
        mouseEnter_Entering = true;
    }

    public void Enter_MouseExit() {
        cardFSMStatus = CardFSMStatus.mouseExit;
        mouseExit_Entering = true;
    }

}