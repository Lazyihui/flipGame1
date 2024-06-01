using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameBusiness {

    public static void Enter(BusinessContext ctx) {

        UIApp.Panel_Step_Open(ctx.uiContext, 10);


        CardDomain.Spawn(ctx, 1, new Vector3(0, 0, 0));
        CardDomain.Spawn(ctx, 3, new Vector3(-4, 0, 0));
        CardDomain.Spawn(ctx, 2, new Vector3(4, 0, 0));
        CardDomain.Spawn(ctx, 4, new Vector3(0, 4, 0));
        CardDomain.Spawn(ctx, 1, new Vector3(0, -4, 0));
        CardDomain.Spawn(ctx, 2, new Vector3(4, 4, 0));
        CardDomain.Spawn(ctx, 3, new Vector3(-4, 4, 0));
        CardDomain.Spawn(ctx, 4, new Vector3(4, -4, 0));
        CardDomain.Spawn(ctx, 5, new Vector3(-4, -4, 0));
        CardDomain.Spawn(ctx, 6, new Vector3(-8, 4, 0));
        CardDomain.Spawn(ctx, 7, new Vector3(-8, 0, 0));
        CardDomain.Spawn(ctx, 8, new Vector3(-8, -4, 0));
        CardDomain.Spawn(ctx, 5, new Vector3(-8, 8, 0));
        CardDomain.Spawn(ctx, 6, new Vector3(-4, 8, 0));
        CardDomain.Spawn(ctx, 7, new Vector3(0, 8, 0));
        CardDomain.Spawn(ctx, 8, new Vector3(4, 8, 0));
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

            CardDomain.Enter_Rotate(ctx, card, dt);


            CardContraller.Tick(ctx, card, dt);

        }
    }

    // static IEnumerator IE(BusinessContext ctx, float dt) {
    //     yield return new WaitForSeconds(1f);
    //     CardDomain.CardIsEqual(ctx, dt);

    // }

    public static void LateTick(BusinessContext ctx, float dt) {

        ctx.inputEntity.Reset();
    }

}