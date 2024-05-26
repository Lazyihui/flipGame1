using System;
using UnityEngine;

public static class GameBusiness {

    public static void Enter(BusinessContext ctx) {

        CardDomain.Spawn(ctx, 1);

    }
    public static void FixedTick(BusinessContext ctx, float dt) {

    }

    public static void PreTick(BusinessContext ctx, float dt) {
        InputEntity input = ctx.inputEntity;
        input.mouseScreenPos = Input.mousePosition;

        Camera camera = ctx.mainCamera;

        // input.mouseWorldPos = camera.ScreenToWorldPoint(new Vector3(input.mouseScreenPos.x, input.mouseScreenPos.y, camera.nearClipPlane));
        input.mouseWorldPos = camera.ScreenToWorldPoint(input.mouseScreenPos);
        if(Input.GetMouseButtonDown(0)) {
            input.isMouseLeftDown = true;
        }
        


    }

    public static void LateTick(BusinessContext ctx, float dt) {

        ctx.inputEntity.Reset();
    }

}