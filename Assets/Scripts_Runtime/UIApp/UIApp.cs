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

    public static void Panel_Login_Open(UIContext ctx) {
        Panel_Login panel = ctx.panel_Login;

        if (panel == null) {
            bool has = ctx.assetsContext.TryGetPanel("Panel_Login", out GameObject prefab);
            if (!has) {
                Debug.LogError("Panel_Login not found");
                return;
            }

            panel = GameObject.Instantiate(prefab, ctx.canvas.transform).GetComponent<Panel_Login>();
            panel.Ctor();
            panel.OnStartHandle = () => {
                ctx.uiEvents.Login_StartGame();
            };

        }
        ctx.panel_Login = panel;
        panel.Show();
    }

    public static void Panel_Login_Close(UIContext ctx) {
        Panel_Login panel = ctx.panel_Login;
        if (panel != null) {
            panel.Close();
        }
    }

    public static void Panel_Over_Open(UIContext ctx, int stepCount) {
        Panel_Over panel = ctx.panel_Over;
        if (panel == null) {
            bool has = ctx.assetsContext.TryGetPanel("Panel_Over", out GameObject prefab);
            if (!has) {
                Debug.LogError("Panel_Over not found");
                return;
            }
            panel = GameObject.Instantiate(prefab, ctx.canvas.transform).GetComponent<Panel_Over>();
            panel.Ctor();
            panel.SetStepCount(stepCount);
            panel.OnRestartHandle = () => {
                ctx.uiEvents.Over_RestartGame();
            };
        }
        ctx.panel_Over = panel;
        panel.Show();

    }

    public static void Panel_Over_Close(UIContext ctx) {
        Panel_Over panel = ctx.panel_Over;
        if (panel != null) {
            panel.Close();
        }
    }



}