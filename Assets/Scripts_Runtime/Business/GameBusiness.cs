using System;
using UnityEngine;

public static class GameBusiness {

    public static void Enter(BusinessContext ctx) {

        CardDomain.Spawn(ctx, 1);

    }


    public static void PreTick(BusinessContext ctx, float dt) {
        InputEntity input = ctx.inputEntity;
        input.mouseScreenPos = Input.mousePosition;

        Camera camera = ctx.mainCamera;

        // input.mouseWorldPos = camera.ScreenToWorldPoint(new Vector3(input.mouseScreenPos.x, input.mouseScreenPos.y, camera.nearClipPlane));
        input.mouseWorldPos = camera.ScreenToWorldPoint(input.mouseScreenPos);
        if (Input.GetMouseButtonDown(0)) {
            input.isMouseLeftDown = true;
        }




    }
    public static void FixedTick(BusinessContext ctx, float dt) {
        //  for card
        int cardLenth = ctx.cardRepository.TakeAll(out CardEntity[] cards);
        for (int i = 0; i < cardLenth; i++) {
            CardEntity card = cards[i];
            bool isMouseInsideCard = CardDomain.MouseInsideCard(ctx, card);
            if (isMouseInsideCard && ctx.inputEntity.isMouseLeftDown) {

                card.transform.rotation = Quaternion.Euler(0, 180, 0);
                
                Debug.Log("鼠标在卡片上");
            }
            // if (CardDomain.MouseInsideCard(ctx, card)) {
            //     card.SetMaterial(Color.red);
            // } else {
            //     card.SetMaterial(Color.white);
            // }
        }
    }
    public static void LateTick(BusinessContext ctx, float dt) {

        ctx.inputEntity.Reset();
    }

}