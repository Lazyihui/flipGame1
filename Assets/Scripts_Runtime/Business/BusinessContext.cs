using System;
using System.Collections.Generic;
using UnityEngine;

public class BusinessContext {

    public AssetsContext assetsContext;

    public TemplateContext templateContext;

    public Camera mainCamera;


    public InputEntity inputEntity;

    public CardRepository cardRepository;

    public List<CardEntity> cards; 


    public int cardCount;
    public BusinessContext() {
        cardRepository = new CardRepository();
        inputEntity = new InputEntity();
        cardCount = 0;
        cards = new List<CardEntity>();
    }

    public void Inject(TemplateContext templateContext, AssetsContext assetsContext, Camera mainCamera) {
        this.templateContext = templateContext;
        this.assetsContext = assetsContext;
        this.mainCamera = mainCamera;
    }

}