using System;
using System.Collections.Generic;
using UnityEngine;

public class BusinessContext {

    public AssetsContext assetsContext;

    public TemplateContext templateContext;

    public UIContext uiContext;

    public Camera mainCamera;


    public InputEntity inputEntity;

    public GameEntity gameEntity;

    public CardRepository cardRepository;

    public List<CardEntity> cards;


    public int cardCount;
    public BusinessContext() {
        cardRepository = new CardRepository();
        inputEntity = new InputEntity();
        gameEntity = new GameEntity();
        cardCount = 0;
        cards = new List<CardEntity>();
    }

    public void Inject(TemplateContext templateContext, AssetsContext assetsContext, Camera mainCamera, UIContext uiContext) {
        this.templateContext = templateContext;
        this.assetsContext = assetsContext;
        this.mainCamera = mainCamera;
        this.uiContext = uiContext;
    }

}