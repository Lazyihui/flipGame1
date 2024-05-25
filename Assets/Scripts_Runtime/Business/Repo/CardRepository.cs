using System;
using System.Collections.Generic;


public class CardRepository {

    Dictionary<int, CardEntity> all;

    CardEntity[] temArray;

    public CardRepository() {
        all = new Dictionary<int, CardEntity>();
        temArray = new CardEntity[10];
    }

    public void Add(CardEntity entity) {
        all.Add(entity.id, entity);
    }

    public void Remove(CardEntity entity) {
        all.Remove(entity.id);
    }

    public int TakeAll(out CardEntity[] array) {
        if (all.Count > temArray.Length) {
            temArray = new CardEntity[all.Count * 2];
        }
        all.Values.CopyTo(temArray, 0);

        array = temArray;
        return all.Count;

    }

    public bool TryGet(int id, out CardEntity entity) {
        return all.TryGetValue(id, out entity);
    }

    public void Foreach(Action<CardEntity> action) {
        foreach (var item in all.Values) {
            action(item);
        }
    }


}