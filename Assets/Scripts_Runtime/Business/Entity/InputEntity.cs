using UnityEngine;

public class InputEntity {

    public Vector2 mouseScreenPos;
    public Vector3 mouseWorldPos;

    public bool isMouseLeftDown;

    public InputEntity() {
    }

    public void Reset() {
        mouseScreenPos = Vector2.zero;
        mouseWorldPos = Vector3.zero;
        isMouseLeftDown = false;
    }




}