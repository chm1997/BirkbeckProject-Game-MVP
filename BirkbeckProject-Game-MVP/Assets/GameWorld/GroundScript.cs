using UnityEngine;

public class GroundScript : MonoBehaviour
{
    /// <summary>
    /// This class moves a collider object around the x position of the player object, while retaining its y position
    /// </summary>

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
