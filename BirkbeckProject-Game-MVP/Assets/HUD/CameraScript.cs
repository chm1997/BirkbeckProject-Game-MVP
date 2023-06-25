using UnityEngine;

public class CameraScript : MonoBehaviour
{
    /// <summary>
    /// This class moves the object around the player object with an offset y position
    /// </summary>

    private Transform playerTransform;
    private void Start()
    {
        // Set up variables required for class functionality
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        UpdateCameraPosition();
    }

    private void UpdateCameraPosition()
    {
        //This method updates the camera position to follow the player object along the x axis
        float playerXPos = playerTransform.position.x;
        float playerYPos = playerTransform.position.y + 5;

        transform.position = new Vector3(playerXPos, 4.5f, -10);
    }
}
