using System;
using UnityEngine;
using UnityEngine.UI;
public class Context {

    public BusinessContext businessContext;

    public AssetsContext assetsContext;
    public TemplateContext templateContext;

    public UIContext uiContext;



    public Camera mainCamera;

    public Canvas canvas;

    public Context() {
        businessContext = new BusinessContext();
        assetsContext = new AssetsContext();
        templateContext = new TemplateContext();
        uiContext = new UIContext();
    }

    public void Inject(Camera mainCamera,Canvas canvas) {
        businessContext.Inject(templateContext,assetsContext,mainCamera,uiContext);
        uiContext.Inject(canvas,assetsContext);
    }

}