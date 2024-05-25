using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

    Context ctx;

    bool isTearDown = false;
    void Awake() {

        ctx = new Context();

        ModuleAssets.Load(ctx.businessContext.assetsContext);

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
        ModuleAssets.Unload(ctx.businessContext.assetsContext);
    }
}
