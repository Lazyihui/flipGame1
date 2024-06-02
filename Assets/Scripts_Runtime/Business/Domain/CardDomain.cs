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
        card.Rotate_Entering = false;
        card.mouseEnter_Entering = false;
        card.mouseExit_Entering = false;
        card.ishasRotate = false;
        card.Rotation_maintainTime = 0f;
        card.ReRotation_maintainTime = 0f;
        card.MouseEnter_maintainTime = 0f;
        card.MouseEnter_maintainInterval = 1f;
        card.id = ctx.cardIDRecord++;
        card.type = tm.type;
        card.typeName = tm.typeName;
        card.SetMaterial(tm.material);
        card.SetPosition(position);
        ctx.cardRepository.Add(card);

        return card;

    }

    // 鼠标和卡片的交叉检测
    static CardEntity MouseInsideCard(BusinessContext ctx) {
        Ray ray = ctx.mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) {


            return hit.collider.gameObject.GetComponent<CardEntity>();
        }
        return null;
    }
    // 如果MouseInsideCard card缓动旋转180度
    // 缓动的转180度



    public static void RotateDone(BusinessContext ctx, CardEntity card) {


        CardEntity resultCard = ctx.cards.Find((insideCard) => {
            if (insideCard.id == card.id) {
                return true;
            }
            return false;
        });

        if (resultCard != null) {
            return;
        }


        ctx.cards.Add(card);
        
        Debug.Assert(ctx.cards.Count <= 2, "数量不能超过2");


        int count = ctx.cards.Count;

        if (count == 2) {

            CardEntity card1 = ctx.cards[0];
            CardEntity card2 = ctx.cards[1];

            if (card1.type == card2.type) {
                card1.Enter_Idle();
                card2.Enter_Idle();
                ctx.cards.Clear();

            } else {
                card1.Enter_ReRetate();
                card2.Enter_ReRetate();
                ctx.cards.Clear();
                card1.ishasRotate = false;
                card2.ishasRotate = false;
            }

        } else {
            card.Enter_Idle();
        }

    }

    public static void Enter_Rotate(BusinessContext ctx, float dt) {
        if (Input.GetMouseButtonDown(0)) {
            CardEntity card = MouseInsideCard(ctx);
            if (card != null && !card.ishasRotate) {
                card.Enter_Rotate();
            }



        }
    }

    public static Vector2 RandomCardPosition() {
        float x = UnityEngine.Random.Range(-8, 8);
        float y = UnityEngine.Random.Range(-4, 4);
        return new Vector2(x, y);
    }




}