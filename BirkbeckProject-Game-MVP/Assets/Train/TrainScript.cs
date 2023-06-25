using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainScript : MonoBehaviour
{
    public TrainDataScriptableObject trainData;

    SpriteRenderer trainFrontSpriteRenderer;
    private SpriteRenderer playerSpriteRenderer;
    private Vector3 playerPosForContains;
    private Vector3 playerPosForAbove;

    private void Awake()
    {
        TrainDataSetUp();   
    }

    private void Start()
    {
        trainFrontSpriteRenderer = this.gameObject.transform.Find("TrainMainSpriteObject").transform.Find("TrainFrontSprite").GetComponent<SpriteRenderer>();
        playerSpriteRenderer = GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        TrackPlayerPositionInRelationToTrain();
    }

    private void TrackPlayerPositionInRelationToTrain()
    {
        if (playerSpriteRenderer != null & trainFrontSpriteRenderer != null)
        {
            playerPosForContains = new Vector3(playerSpriteRenderer.bounds.center.x, playerSpriteRenderer.bounds.center.y, -2);
            playerPosForAbove = new Vector3(playerSpriteRenderer.bounds.center.x, trainFrontSpriteRenderer.bounds.center.y, -2);

            trainData.SetPlayerInTrain(trainFrontSpriteRenderer.bounds.Contains(playerPosForContains));
            trainData.SetPlayerAboveTrain(trainFrontSpriteRenderer.bounds.Contains(playerPosForAbove));
        }
    }

    private void TrainDataSetUp()
    {
        trainData.SetMaxTrainFuel(1000);
        trainData.SetTrainFuel(1000);

        trainData.SetMaxTrainHealth(1000);
        trainData.SetTrainHealth(1000);

        trainData.SetMaxTrainSpeed(100);
        trainData.SetTrainSpeed(0);

        trainData.SetPlayerInTrain(false);
        trainData.SetPlayerAboveTrain(false);
    }
}
