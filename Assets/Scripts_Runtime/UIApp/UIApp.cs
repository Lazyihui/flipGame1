using System;
using UnityEngine;

public static class UIApp {

    public static void Panel_Step_Open(UIContext ctx, int count) {
        Panel_Step panel = ctx.panel_Step;

        if (panel == null) {
            Debug.Assert(ctx.canvas != null, "canvas is null");
            Debug.Assert(ctx.assetsContext != null, "assetsContext is null");

            bool has = ctx.assetsContext.TryGetPanel("Panel_Step", out GameObject prefab);
            if (!has) {
                Debug.LogError("Panel_Step not found");
                return;
            }

            panel = GameObject.Instantiate(prefab, ctx.canvas.transform).GetComponent<Panel_Step>();
            panel.SetStepCount(count);

        }
        ctx.panel_Step = panel;
        panel.Show();
    }


}