using UnityEngine;

public static class CardDomain {
    public static CardEntity Spawn(BusinessContext ctx, int id) {


        bool has = ctx.templateContext.cards.TryGetValue(id, out CardTM tm);

        if (!has) {

            Debug.LogError("没有找到对应的模板");
            return null;
        }

        ctx.assetsContext.entities.TryGetValue("CardEntity", out GameObject prefab);


        CardEntity card = GameObject.Instantiate(prefab).GetComponent<CardEntity>();
        card.Ctor();
        card.id = tm.id;
        card.type = tm.type;
        card.typeName = tm.typeName;
        card.SetMaterial(tm.material);
        ctx.cardRepository.Add(card);

        return card;

    }

    // 鼠标和卡片的交叉检测
    public static bool MouseInsideCard(BusinessContext ctx,CardEntity card) {
        Ray ray = ctx.mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) {
            if (hit.collider.gameObject == card.gameObject) {
                return true;
            }
        }

        return false;

    }


    // public static bool CheckMouseCard(CardEntity card) {
    //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //     RaycastHit hit;
    //     if (Physics.Raycast(ray, out hit)) {
    //         if (hit.collider.gameObject == card.gameObject) {
    //             return true;
    //         }
    //     }
    //     return false;
    // }


}