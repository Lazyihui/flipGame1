using System;
using UnityEngine;
using UnityEngine.UI;

public class Panel_Step : MonoBehaviour {

    [SerializeField] Text stepCount;


    public Panel_Step() { }

    public void SetStepCount(int count) {
        stepCount.text = count.ToString();
    }
    public void Show() {
        gameObject.SetActive(true);
    }

}