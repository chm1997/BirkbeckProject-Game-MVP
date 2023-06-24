using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainAnimationScript : MonoBehaviour
{
    SpriteRenderer trainFrontSpriteRenderer;
    public SpriteRenderer playerSpriteRenderer;
    public Vector3 playerPosForContains;

    private void Start()
    {
        trainFrontSpriteRenderer = this.gameObject.transform.Find("TrainFrontSprite").GetComponent<SpriteRenderer>();
        playerSpriteRenderer = GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        playerPosForContains = new Vector3(playerSpriteRenderer.bounds.center.x, playerSpriteRenderer.bounds.center.y, -2);
        trainFrontSpriteRenderer.enabled = !trainFrontSpriteRenderer.bounds.Contains(playerPosForContains);
    }
}
