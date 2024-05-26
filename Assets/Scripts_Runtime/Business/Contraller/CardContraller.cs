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

        } else {
            Debug.Log("未知状态,状态机异常");
        }
        Any_State(ctx, card, dt);
    }

    static void Any_State(BusinessContext ctx, CardEntity card, float dt) {
    }

    static void Idle(BusinessContext ctx, CardEntity card, float dt) {
        if (card.Idle_Entering) {
            card.Idle_Entering = false;
            Debug.Log("Enter Idle");
        }


    }

    static void Rotate(BusinessContext ctx, CardEntity card, float dt) {
        if (card.Rotate_Entering) {
            card.Rotate_Entering = false;
            Debug.Log("Enter Rotate");
        }


        float t = card.Rotation_maintainTime / card.Rotation_maintainInterval;
        float value = 180 * t;
        card.transform.rotation = Quaternion.Euler(0, value, 0);

        card.Rotation_maintainTime += dt;

        if (card.Rotation_maintainTime >= card.Rotation_maintainInterval) {

            card.Enter_Idle();

            return;
        }


    }




}