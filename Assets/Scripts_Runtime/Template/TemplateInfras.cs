using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;


public class TemplateInfras {

    public static void Load(TemplateContext ctx) {

        {
            AssetLabelReference labelReference = new AssetLabelReference();
            labelReference.labelString = "TM_Card";
            var ptr = Addressables.LoadAssetsAsync<CardTM>(labelReference, null);
            var list = ptr.WaitForCompletion();
            foreach (var go in list) {
                ctx.cards.Add(go.id, go);
            }
            ctx.cardPtr = ptr;

        }

    }

    public static void Unload(TemplateContext ctx) {
        if (ctx.cardPtr.IsValid()) {
            Addressables.Release(ctx.cardPtr);
        }
    }
}