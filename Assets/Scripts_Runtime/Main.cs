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

        ctx = new Context();
        ctx.Inject(mainCamera, canvas);

        ModuleAssets.Load(ctx.assetsContext);
        TemplateInfras.Load(ctx.templateContext);

        UIApp.Panel_Login_Open(ctx.uiContext);

        binding();

        GameBusiness.Enter(ctx.businessContext);


    }
    void binding() {
        var uiEvents = ctx.uiContext.uiEvents;

        uiEvents.OnStartHandle = () => {
            UIApp.Panel_Login_Close(ctx.uiContext);
            GameBusiness.Enter(ctx.businessContext);
        };

    }
    float restDT = 0;
    void Update() {
        float dt = Time.deltaTime;

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
