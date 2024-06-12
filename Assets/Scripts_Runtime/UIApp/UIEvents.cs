using System;


public class UIEvents {

    public Action OnStartHandle;

    public void Login_StartGame() {
        if (OnStartHandle != null) {
            OnStartHandle.Invoke();
        }
    }


    public Action OnRestartHandle;

    public void Over_RestartGame() {
        if (OnRestartHandle != null) {
            OnRestartHandle.Invoke();
        }
    }



}