using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

    Context ctx;

    bool isTearDown = false;
    void Awake() {
        Camera mainCamera = gameObject.transform.Find("Main Camera").GetComponent<Camera>();
        Canvas canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        //  === Init ===
        ctx = new Context();
        // === Inject ===
        ctx.Inject(mainCamera, canvas);

        // === Load ===
        ModuleAssets.Load(ctx.assetsContext);
        TemplateInfras.Load(ctx.templateContext);

        UIApp.Panel_Login_Open(ctx.uiContext);
        // === Binding ===
        binding();

    }
    void binding() {
        var uiEvents = ctx.uiContext.uiEvents;

        uiEvents.OnStartHandle = () => {
            ctx.businessContext.gameEntity.gameFSMSStatus = GameFSMStatus.Game;
            UIApp.Panel_Login_Close(ctx.uiContext);
            GameBusiness.Enter(ctx.businessContext);
        };

    }
    float restDT = 0;
    void Update() {




        float dt = Time.deltaTime;

        GameFSMStatus status = ctx.businessContext.gameEntity.gameFSMSStatus;

        if (status == GameFSMStatus.Login) {

        } else if (status == GameFSMStatus.Game) {


            GameBusiness.PreTick(ctx.businessContext, dt);

            restDT += dt;

            float fixedDT = Time.fixedDeltaTime; // 0.02
            restDT += dt;// 0.0083 (0.0000000001, 10)
            if (restDT >= fixedDT) {
                while (restDT >= fixedDT) {
                    restDT -= fixedDT;
                    FixedTick(fixedDT);
                }
            } else {
                FixedTick(restDT);
                restDT = 0;
            }

            // LateTick
            GameBusiness.LateTick(ctx.businessContext, dt);

        } else if (status == GameFSMStatus.GameOver) {

        }




    }

    void FixedTick(float dt) {
        // === Phase:Logic===
        GameBusiness.FixedTick(ctx.businessContext, dt);
        // === phade: Simulate===
    }

    void OnApplicationQuit() {
        TearDown();
    }
    void OnDestroy() {
        TearDown();
    }

    void TearDown() {
        if (isTearDown) {
            return;
        }
        isTearDown = true;
        ModuleAssets.Unload(ctx.assetsContext);
        TemplateInfras.Unload(ctx.templateContext);
    }
}
