using UnityEngine;

public class GroundScript : MonoBehaviour
{
    /// <summary>
    /// This class moves a collider object around the x position of the player object, while retaining its y position
    /// </summary>

    private Transform playerTransform;
    private float textureUnitSizeX;

    private void Start()
    {
        // Set up required variables
        playerTransform = GameObject.FindWithTag("Player").transform;

        CalculateTextureSize();
    }
    private void Update()
    {
        TransformPositionAroundPlayerPosition();
    }

    private void CalculateTextureSize()
    {
        // This method calculates how wide the assigned objects' sprite is wide
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
    }

    private void TransformPositionAroundPlayerPosition()
    {
        // This method transforms the assigned objects' towards the player on the x axis, offset by texture width to prevent visible stuttering
        if (Mathf.Abs(playerTransform.position.x - transform.position.x) >= textureUnitSizeX)
        {
            transform.position = new Vector2(playerTransform.position.x, transform.position.y);
        }
    }
}
