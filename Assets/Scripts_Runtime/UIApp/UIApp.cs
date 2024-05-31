using System;
using UnityEngine;

public static class UIApp {

    public static void Panel_Step_Open(UIContext ctx) {
        Panel_Step panel = ctx.panel_Step;

        if (panel == null) {
            bool has = ctx.assetsContext.TryGetPanel("Panel_Step", out GameObject prefab);
            if (!has) {
                Debug.LogError("Panel_Step not found");
                return;
            }

            panel = GameObject.Instantiate(prefab, ctx.canvas.transform).GetComponent<Panel_Step>();


        }
        ctx.panel_Step = panel;
        panel.Show();
    }


}