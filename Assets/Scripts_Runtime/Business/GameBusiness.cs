using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameBusiness {

    public static void Enter(BusinessContext ctx) {
        ctx.gameEntity.stepCount = 0;

        UIApp.Panel_Step_Open(ctx.uiContext, ctx.gameEntity.stepCount);

        // 随机生成卡片位置
        List<Vector3Int> cards = new List<Vector3Int> {
            new Vector3Int(0, 0, 0),
            new Vector3Int(-4, 0, 0),
            new Vector3Int(4, 0, 0),
            new Vector3Int(0, 4, 0),
            new Vector3Int(0, -4, 0),
            new Vector3Int(4, 4, 0),
            new Vector3Int(-4, 4, 0),
            new Vector3Int(4, -4, 0),
            new Vector3Int(-4, -4, 0),
            new Vector3Int(-8, 4, 0),
            new Vector3Int(-8, 0, 0),
            new Vector3Int(-8, -4, 0),
            new Vector3Int(-8, 8, 0),
            new Vector3Int(-4, 8, 0),
            new Vector3Int(0, 8, 0),
            new Vector3Int(4, 8, 0),
        };

        int[] arrayRandom = new int[16] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
        int[] randomId = new int[16] { 1, 2, 3, 4, 5, 6, 7, 8, 1, 2, 3, 4, 5, 6, 7, 8 };

        int count = arrayRandom.Length;

        while (count > 1) {
            count--;
            int index = new System.Random().Next(count + 1);
            Console.WriteLine("index: " + index);
            int temp = arrayRandom[index];
            arrayRandom[index] = arrayRandom[count];
            arrayRandom[count] = temp;
        }

        int count1 = randomId.Length;

        while (count1 > 1) {
            count1--;
            int index = new System.Random().Next(count1 + 1);
            Console.WriteLine("index: " + index);
            int temp = randomId[index];
            randomId[index] = randomId[count1];
            randomId[count1] = temp;
        }




        for (int i = 0; i < cards.Count; i++) {
            CardDomain.Spawn(ctx, randomId[i], cards[arrayRandom[i]]);
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

        CardDomain.Enter_Rotate(ctx,  dt);


    }
    public static void FixedTick(BusinessContext ctx, float dt) {
        //  for card
        int cardLenth = ctx.cardRepository.TakeAll(out CardEntity[] cards);
        for (int i = 0; i < cardLenth; i++) {
            CardEntity card = cards[i];

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