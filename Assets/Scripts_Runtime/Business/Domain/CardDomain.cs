using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
        card.MouseInside = false;
        card.Rotate_Entering = false;
        card.mouseEnter_Entering = false;
        card.mouseExit_Entering = false;
        card.isRotatingOver = false;
        card.Rotation_maintainTime = 0f;
        card.Rotation_maintainInterval = 1f;
        card.MouseEnter_maintainTime = 0f;
        card.MouseEnter_maintainInterval = 1f;
        card.id = ctx.cardCount++;
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

                card.MouseInside = true;
                return true;
            }
        }
        card.MouseInside = false;
        return false;

    }
    // 如果MouseInsideCard card缓动旋转180度
    // 缓动的转180度


    public static void Enter_Rotate(BusinessContext ctx, CardEntity card, float dt) {
        if (MouseInsideCard(ctx, card) && Input.GetMouseButtonDown(0)) {

            ctx.cards.Add(card);

            card.Enter_Rotate();

        }
    }

    // 前面点击的name和这个name是否一样

    public static void CardIsEqual(BusinessContext ctx, float dt) {

        int count = ctx.cards.Count;
        if (count == 2) {
            ctx.cardRepository.TryGet(ctx.cards[0].id, out CardEntity card1);
            ctx.cardRepository.TryGet(ctx.cards[1].id, out CardEntity card2);
            if (card1.type == card2.type) {
                Debug.Log("相同");
                card1.Enter_Idle();
                card2.Enter_Idle();

            } else {
                Debug.Log("不相同");
                card1.Enter_ReRetate();
                card2.Enter_ReRetate();

            }


            ctx.cards.Clear();
        }

    }




}