using UnityEngine;

public static class CardDomain {
    public static CardEntity Spawn(BusinessContext ctx) { 
        
        Debug.Assert(ctx != null, "BusinessContext is null");
        Debug.Assert(ctx.assetsContext != null, "AssetsContext is null");
        Debug.Assert(ctx.assetsContext.entities != null, "Entities is null");

        
        bool has = ctx.assetsContext.entities.TryGetValue("CardEntity", out GameObject prefab);

        if(!has) {
            Debug.LogError("Card prefab not found");
            return null;
        }

        CardEntity card = GameObject.Instantiate(prefab).GetComponent<CardEntity>();
        card.Ctor();

        ctx.cardRepository.Add(card);

        return card;

    }


}