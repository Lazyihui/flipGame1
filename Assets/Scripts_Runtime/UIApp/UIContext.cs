using System;
using UnityEngine;

public class UIContext {

    public Panel_Step panel_Step;


    //  Inject
    public Canvas canvas;

    public AssetsContext assetsContext;
    public UIContext() { }

    public void Inject(Canvas canvas,AssetsContext assetsContext) {
        this.canvas = canvas;
        this.assetsContext = assetsContext;

    }
}