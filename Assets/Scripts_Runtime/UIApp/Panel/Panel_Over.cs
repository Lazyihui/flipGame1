using System;
using UnityEngine;
using UnityEngine.UI;

public class Panel_Over : MonoBehaviour {
    [SerializeField] Button btn_Restart;

    [SerializeField] Button btn_Over;

    [SerializeField] Text txt_StepCount;

    [SerializeField] Text txt_GoalCount;

    public Action OnRestartHandle;

    public Action OnOverHandle;


    public void Ctor() {
        btn_Over.onClick.AddListener(() => {
            OnOverHandle.Invoke();
        });

        btn_Restart.onClick.AddListener(() => {
            OnRestartHandle.Invoke();
        });
    }

    public void SetStepCount(int count) {
        txt_StepCount.text = count.ToString();
    }

    public void Show() {
        gameObject.SetActive(true);
    }

    public void Close() {
        gameObject.SetActive(false);
    }

}


