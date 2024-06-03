using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel_Login : MonoBehaviour {
    [SerializeField] Button btn_Exit;

    [SerializeField] Button btn_Start;

    public Action OnStartHandle;

    public Action OnExitHandle;

    public void Show() {
        gameObject.SetActive(true);
    }

    public void Close() {
        gameObject.SetActive(false);
    }

    public void Ctor() {
        btn_Exit.onClick.AddListener(() => {
            OnExitHandle.Invoke();
        });

        btn_Start.onClick.AddListener(() => {
            OnStartHandle.Invoke();
        });
    }

}