using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

    Context ctx;

    bool isTearDown = false;
    void Awake() {
        Camera mainCamera = gameObject.transform.Find("Main Camera").GetComponent<Camera>();
        Canvas canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        //  === Init ===
        ctx = new Context();
        // === Inject ===
        ctx.Inject(mainCamera, canvas);

        // === Load ===
        ModuleAssets.Load(ctx.assetsContext);
        TemplateInfras.Load(ctx.templateContext);

        UIApp.Panel_Login_Open(ctx.uiContext);
        // === Binding ===
        binding();

    }
    void binding() {
        var uiEvents = ctx.uiContext.uiEvents;

        uiEvents.OnStartHandle = () => {
            ctx.businessContext.gameEntity.gameFSMSStatus = GameFSMStatus.Game;
            UIApp.Panel_Login_Close(ctx.uiContext);
            GameBusiness.Enter(ctx.businessContext);
        };

        uiEvents.OnRestartHandle = () => {
            ctx.businessContext.gameEntity.gameFSMSStatus = GameFSMStatus.Game;
            UIApp.Panel_Over_Close(ctx.uiContext);
            GameBusiness.Enter(ctx.businessContext);
        };

    }
    float restDT = 0;
    void Update() {




        float dt = Time.deltaTime;

        GameFSMStatus status = ctx.businessContext.gameEntity.gameFSMSStatus;

        if (status == GameFSMStatus.Login) {

        } else if (status == GameFSMStatus.Game) {


            GameBusiness.PreTick(ctx.businessContext, dt);

            restDT += dt;

            float fixedDT = Time.fixedDeltaTime; // 0.02
            restDT += dt;// 0.0083 (0.0000000001, 10)
            if (restDT >= fixedDT) {
                while (restDT >= fixedDT) {
                    restDT -= fixedDT;
                    FixedTick(fixedDT);
                }
            } else {
                FixedTick(restDT);
                restDT = 0;
            }

            // LateTick
            GameBusiness.LateTick(ctx.businessContext, dt);

        } else if (status == GameFSMStatus.GameOver) {
            
        }




    }

    void FixedTick(float dt) {
        // === Phase:Logic===
        GameBusiness.FixedTick(ctx.businessContext, dt);
        // === phade: Simulate===
        // 需要重构一下
        if (ctx.businessContext.gameEntity.hasRotateCardnum >= 16) {

            ctx.businessContext.gameEntity.gameFSMSStatus = GameFSMStatus.GameOver;
            // 疑问 它这个打开是不是运行的很多遍
            UIApp.Panel_Over_Open(ctx.uiContext, ctx.businessContext.gameEntity.stepCount);

            // 清空数据
            ctx.businessContext.gameEntity.hasRotateCardnum = 0;
            ctx.businessContext.gameEntity.stepCount = 0;

            // 清空卡片
            int cardLenth = ctx.businessContext.cardRepository.TakeAll(out CardEntity[] cards);
            for (int i = 0; i < cardLenth; i++) {
                CardEntity card = cards[i];
                CardDomain.Destroy(ctx.businessContext, card);
            }

            



        }

    }

    void OnApplicationQuit() {
        TearDown();
    }
    void OnDestroy() {
        TearDown();
    }

    void TearDown() {
        if (isTearDown) {
            return;
        }
        isTearDown = true;
        ModuleAssets.Unload(ctx.assetsContext);
        TemplateInfras.Unload(ctx.templateContext);
    }
}
