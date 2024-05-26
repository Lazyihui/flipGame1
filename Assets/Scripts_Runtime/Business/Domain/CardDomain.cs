using UnityEngine;

public static class CardDomain {
    public static CardEntity Spawn(BusinessContext ctx, int id, Vector3 position) {


        bool has = ctx.templateContext.cards.TryGetValue(id, out CardTM tm);

        if (!has) {

            Debug.LogError("没有找到对应的模板");
            return null;
        }

        ctx.assetsContext.entities.TryGetValue("CardEntity", out GameObject prefab);


        CardEntity card = GameObject.Instantiate(prefab).GetComponent<CardEntity>();
        card.Ctor();
        card.cardFSMStatus = CardFSMStatus.None;
        card.Enter_Idle();
        card.Rotate_Entering = false;
        card.Rotation_maintainTime = 0f;
        card.Rotation_maintainInterval = 1f;
        card.id = tm.id;
        card.type = tm.type;
        card.typeName = tm.typeName;
        card.SetMaterial(tm.material);
        card.SetPosition(position);
        ctx.cardRepository.Add(card);

        return card;

    }

    // 鼠标和卡片的交叉检测
    static bool MouseInsideCard(BusinessContext ctx, CardEntity card) {
        Ray ray = ctx.mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) {
            if (hit.collider.gameObject == card.gameObject) {
                return true;
            }
        }

        return false;

    }
    // 如果MouseInsideCard card缓动旋转180度
    // 缓动的转180度


    public static void RotateCard(BusinessContext ctx, CardEntity card, float dt) {
        if (MouseInsideCard(ctx, card) && Input.GetMouseButtonDown(0)) {

            card.Enter_Rotate();
            Debug.Log("Rotate");

        }
    }




}