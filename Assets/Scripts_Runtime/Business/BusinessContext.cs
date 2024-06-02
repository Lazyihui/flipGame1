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


    public int cardIDRecord;

    public int[] arrayRandom;
    public int[] randomId;

    public List<Vector3Int> cardVector3s;

    public BusinessContext() {
        cardRepository = new CardRepository();
        inputEntity = new InputEntity();
        gameEntity = new GameEntity();
        cardIDRecord = 0;
        cards = new List<CardEntity>();
        arrayRandom = new int[16] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
        randomId = new int[16] { 1, 2, 3, 4, 5, 6, 7, 8, 1, 2, 3, 4, 5, 6, 7, 8 };
        cardVector3s = new List<Vector3Int> {
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
    }

    public void Inject(TemplateContext templateContext, AssetsContext assetsContext, Camera mainCamera, UIContext uiContext) {
        this.templateContext = templateContext;
        this.assetsContext = assetsContext;
        this.mainCamera = mainCamera;
        this.uiContext = uiContext;
    }

}