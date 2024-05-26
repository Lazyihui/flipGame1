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

        card.Rotation_maintainInterval -= dt;
        if (card.Rotation_maintainInterval <= 0) {

            card.transform.rotation = Quaternion.Euler(0, 180, 0);

            card.Enter_Idle();
            card.Rotation_maintainInterval = card.Rotation_maintainTimer;
            return;
        }


    }




}