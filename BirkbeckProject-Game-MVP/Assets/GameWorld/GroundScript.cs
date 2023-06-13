using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    private Transform playerTransform;
    private Vector3 lastPlayerPosition;
    private float textureUnitSizeX;

    private void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;

        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
    }
    private void Update()
    {
        if (Mathf.Abs(playerTransform.position.x - transform.position.x) >= textureUnitSizeX)
        {
            transform.position = new Vector2(playerTransform.position.x, transform.position.y);
        }
    }
}
