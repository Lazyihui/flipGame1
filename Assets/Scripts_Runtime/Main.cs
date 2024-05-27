using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

    Context ctx;

    bool isTearDown = false;
    void Awake() {
        Camera mainCamera = gameObject.transform.Find("Main Camera").GetComponent<Camera>();


        ctx = new Context();
        ctx.Inject(mainCamera);

        ModuleAssets.Load(ctx.assetsContext);
        TemplateInfras.Load(ctx.templateContext);

        GameBusiness.Enter(ctx.businessContext);

    }


    IEnumerator IE(BusinessContext ctx, float dt) {
        yield return new WaitForSeconds(1.5f);
        CardDomain.CardIsEqual(ctx, dt);

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
                this.StartCoroutine(IE(ctx.businessContext, fixedDT));
            }
        } else {
            FixedTick(restDT);
            this.StartCoroutine(IE(ctx.businessContext, restDT));
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
