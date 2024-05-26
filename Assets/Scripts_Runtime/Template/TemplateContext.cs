using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;


public class TemplateContext {

    public Dictionary<int, CardTM> cards;

    public AsyncOperationHandle cardPtr;

    public Dictionary<int,BgTM> bgs;

    public AsyncOperationHandle bgPtr;

    public TemplateContext() {
        cards = new Dictionary<int, CardTM>();
        bgs = new Dictionary<int, BgTM>();
    }

}