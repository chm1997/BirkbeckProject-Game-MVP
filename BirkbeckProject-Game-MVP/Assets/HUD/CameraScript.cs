using UnityEngine;

public class CameraScript : MonoBehaviour
{
    /// <summary>
    /// This class moves the object around the player object with an offset y position
    /// </summary>

    private Transform playerTransform;
    private void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {    
        float playerXPos = playerTransform.position.x;
        float playerYPos = playerTransform.position.y + 5;

        transform.position = new Vector3(playerXPos, 4.5f, -10);
    }
}
