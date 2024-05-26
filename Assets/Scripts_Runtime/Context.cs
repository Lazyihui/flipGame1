using System;
using UnityEngine;

public class Context {

    public BusinessContext businessContext;

    public AssetsContext assetsContext;
    public TemplateContext templateContext;


    public Context() {
        businessContext = new BusinessContext();
        assetsContext = new AssetsContext();
        templateContext = new TemplateContext();
    }

    public void Inject() {
        businessContext.Inject(templateContext,assetsContext);
    }

}