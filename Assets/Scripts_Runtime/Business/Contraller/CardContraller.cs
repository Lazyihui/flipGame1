using System;
using UnityEngine;

public static class CardContraller {
    public static void Tick(BusinessContext ctx, CardEntity card, float dt) {
        CardFSMStatus status = card.cardFSMStatus;

        if (status == CardFSMStatus.None) {

        } else if (status == CardFSMStatus.Idle) {

            Idle(ctx, card, dt);
        } else if (status == CardFSMStatus.Rotate) {
            Rotate(ctx, card, dt);

        } else if (status == CardFSMStatus.mouseEnter) {
            MouseEnter(ctx, card, dt);
        } else if (status == CardFSMStatus.mouseExit) {

        } else if (status == CardFSMStatus.ReRetate) {
            ReRotate(ctx, card, dt);

        } else {
            Debug.LogError("没有找到对应的状态");
        }
        Any_State(ctx, card, dt);
    }

    static void Any_State(BusinessContext ctx, CardEntity card, float dt) {
    }

    static void Idle(BusinessContext ctx, CardEntity card, float dt) {
        if (card.Idle_Entering) {
            card.Idle_Entering = false;
        }


    }

    static void Rotate(BusinessContext ctx, CardEntity card, float dt) {
        if (card.Rotate_Entering) {
            card.Rotate_Entering = false;
            card.Rotation_maintainTime = 0;
            card.ishasRotate = true;
            Debug.Log(card.id);
        }


        float t = card.Rotation_maintainTime / 1;
        float value = 180 * t;
        card.transform.rotation = Quaternion.Euler(0, value, 0);

        card.Rotation_maintainTime += dt;

        if (card.Rotation_maintainTime >= 1) {


            CardDomain.RotateDone(ctx, card);
            ctx.gameEntity.stepCount++;
            ctx.uiContext.panel_Step.SetStepCount(ctx.gameEntity.stepCount);


            return;
        }
    }

    public static void ReRotate(BusinessContext ctx, CardEntity card, float dt) {
        if (card.ReRetate_Entering) {
            card.ReRetate_Entering = false;
            card.ReRotation_maintainTime = 0;
        }



        float t = card.Rotation_maintainTime / 2;
        float value = 360 * t;
        // 从180度开始转到0

        card.transform.rotation = Quaternion.Euler(0, -value, 0);

        card.Rotation_maintainTime += dt;
        if (card.Rotation_maintainTime >= 2) {
            card.Enter_Idle();
            return;

        }
    }
    static void MouseEnter(BusinessContext ctx, CardEntity card, float dt) {
        if (card.mouseEnter_Entering) {
            card.mouseEnter_Entering = false;
            Debug.Log("Enter MouseEnter");
        }
        // card 左右摇摆
        float t = card.MouseEnter_maintainTime / card.MouseEnter_maintainInterval;
        float value = 20 * t;
        card.transform.rotation = Quaternion.Euler(0, value, 0);

        card.MouseEnter_maintainTime += dt;
        if (card.MouseEnter_maintainTime >= card.MouseEnter_maintainInterval) {

            card.MouseEnter_maintainTime = 0;
            return;
        }



    }




}