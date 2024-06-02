using System;
using UnityEngine;

public static class Common {
    public static void RandomArray<T>(T[] array) {
     
        for (int i = 0; i < array.Length; i++) {
            int randomIndex = UnityEngine.Random.Range(0, array.Length);
            T temp = array[i];
            array[i] = array[randomIndex];
            array[randomIndex] = temp;
        }

        
    }
}