using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
public class AssetsContext {


    public Dictionary<string, GameObject> entities;


    public AsyncOperationHandle entityPtr;

    public AssetsContext() {
        entities = new Dictionary<string, GameObject>();
        
    }
    public bool TryGetEntity(string name, out GameObject entity) {
        return entities.TryGetValue(name, out entity);
    }

}