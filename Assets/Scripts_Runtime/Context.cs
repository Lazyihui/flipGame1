using System;
using UnityEngine;

public class Context {

    public BusinessContext businessContext;

    public AssetsContext assetsContext;
    public TemplateContext templateContext;

    public Camera mainCamera;


    public Context() {
        businessContext = new BusinessContext();
        assetsContext = new AssetsContext();
        templateContext = new TemplateContext();
    }

    public void Inject(Camera mainCamera) {
        businessContext.Inject(templateContext,assetsContext,mainCamera);
    }

}