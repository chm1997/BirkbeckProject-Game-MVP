using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    /// <summary>
    /// This class moves the object it's attached to relative to the main scene camera to give the appearance of a background.
    /// Required fields:
    /// Vector2 parallaxEffectMultiplier: changes how much the object moves relative to the camera, giving the appearance of distance</param>
    /// </summary>

    public Vector2 parallaxEffectMultiplier;

    private Transform cameraTransform;
    private Vector3 lastCameraPosition;
    private float textureUnitSizeX;

    private void Start()
    {
        cameraTransform = GameObject.FindWithTag("MainCamera").transform;
        lastCameraPosition = cameraTransform.position;

        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        textureUnitSizeX = sprite.texture.width / sprite.pixelsPerUnit;
    }

    private void LateUpdate()
    {
        CalculateCameraTransform();
        MoveObjectRelativeToCamera();
    }

    private void CalculateCameraTransform()
    {
        // This method calculates a transform position for the object based on the distance the camera has moved and the parallaxEffectMultiplier variable

        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier.x, deltaMovement.y * parallaxEffectMultiplier.y);
        lastCameraPosition = cameraTransform.position;
    }

    private void MoveObjectRelativeToCamera()
    {
        // This method implements the transform position on the object if it's large enough compared to the object sprite

        if (Mathf.Abs(cameraTransform.position.x - transform.position.x) >= textureUnitSizeX)
        {
            float offsetPositionX = (cameraTransform.position.x - transform.position.x) % textureUnitSizeX;
            transform.position = new Vector3(cameraTransform.position.x + offsetPositionX, transform.position.y);
        }
    }
}
