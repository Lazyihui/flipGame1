using System;
using UnityEngine;

public class UIContext {

    public Panel_Step panel_Step;

    public Panel_Login panel_Login;

    public UIEvents uiEvents;

    //  Inject
    public Canvas canvas;

    public AssetsContext assetsContext;
    public UIContext() { 
        uiEvents = new UIEvents();

    }

    public void Inject(Canvas canvas,AssetsContext assetsContext) {
        this.canvas = canvas;
        this.assetsContext = assetsContext;

    }
}