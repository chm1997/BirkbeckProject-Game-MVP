using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainAnimationScript : MonoBehaviour
{
    SpriteRenderer trainFrontSpriteRenderer;
    public TrainDataScriptableObject trainData;

    private void Start()
    {
        trainFrontSpriteRenderer = this.gameObject.transform.Find("TrainFrontSprite").GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        trainFrontSpriteRenderer.enabled = !trainData.GetPlayerInTrain();
    }
}
