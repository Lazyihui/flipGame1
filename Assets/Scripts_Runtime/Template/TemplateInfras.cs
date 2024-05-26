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

        {
            AssetLabelReference labelReference = new AssetLabelReference();
            labelReference.labelString = "TM_Bg";
            var ptr = Addressables.LoadAssetsAsync<BgTM>(labelReference, null);
            var list = ptr.WaitForCompletion();
            foreach (var go in list) {
                ctx.bgs.Add(go.id, go);
            }
            ctx.bgPtr = ptr;

        }

    }

    public static void Unload(TemplateContext ctx) {
        if (ctx.cardPtr.IsValid()) {
            Addressables.Release(ctx.cardPtr);
        }
        if (ctx.bgPtr.IsValid()) {
            Addressables.Release(ctx.bgPtr);
        }
    }
}