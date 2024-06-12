using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameBusiness {

    public static void Enter(BusinessContext ctx) {
        ctx.gameEntity.stepCount = 0;

        UIApp.Panel_Step_Open(ctx.uiContext, ctx.gameEntity.stepCount);

        // 随机生成卡片位置

        Common.RandomArray(ctx.arrayRandom);
        Common.RandomArray(ctx.randomId);

        for (int i = 0; i < ctx.cardVector3s.Count; i++) {
            CardDomain.Spawn(ctx, ctx.randomId[i], ctx.cardVector3s[ctx.arrayRandom[i]]);
        }


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

        CardDomain.Enter_Rotate(ctx, dt);


    }
    public static void FixedTick(BusinessContext ctx, float dt) {
        //  for card
        int cardLenth = ctx.cardRepository.TakeAll(out CardEntity[] cards);
        for (int i = 0; i < cardLenth; i++) {
            CardEntity card = cards[i];

            CardContraller.Tick(ctx, card, dt);
        }
        if(ctx.gameEntity.hasRotateCardnum>=16){
            Debug.Log("youxiejieshu");
        }

    }


    public static void LateTick(BusinessContext ctx, float dt) {

        ctx.inputEntity.Reset();
    }

}