using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainAnimationScript : MonoBehaviour
{
    SpriteRenderer trainFrontSpriteRenderer;
    public SpriteRenderer playerSpriteRenderer;
    public Vector3 playerPosForContains;
    public Bounds trainbounds;
    public Transform playerTransform;
    public bool thingbool;

    private void Start()
    {
        trainFrontSpriteRenderer = this.gameObject.transform.Find("TrainFrontSprite").GetComponent<SpriteRenderer>();
        playerSpriteRenderer = GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        trainbounds = trainFrontSpriteRenderer.bounds;
        playerTransform = playerSpriteRenderer.transform;


        playerPosForContains = new Vector3(playerSpriteRenderer.bounds.center.x, playerSpriteRenderer.bounds.center.y, -2);
        thingbool = !trainFrontSpriteRenderer.bounds.Contains(playerPosForContains);
        trainFrontSpriteRenderer.enabled = thingbool;
    }
}
