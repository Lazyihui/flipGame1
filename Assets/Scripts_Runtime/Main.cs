using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

    Context ctx;

    bool isTearDown = false;
    void Awake() {

        ctx = new Context();
        ctx.Inject();

        ModuleAssets.Load(ctx.assetsContext);
        TemplateInfras.Load(ctx.templateContext);

        GameBusiness.Enter(ctx.businessContext);

    }

    void Update() {

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
