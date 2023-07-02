using System.Collections;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    /// <summary>
    /// This class moves the object around the player object with an offset y position
    /// </summary>

    [SerializeField]
    private TrainDataScriptableObject trainData;

    private Camera thisCamera;

    private Transform playerTransform;

    private float playerXPos;

    private float cameraYPosOffset;
    private float cameraSizeOffset;

    private void Start()
    {
        // Set up variables required for class functionality
        playerTransform = GameObject.FindWithTag("Player").transform;
        thisCamera = GetComponent<Camera>();

        cameraYPosOffset = 0;
        cameraSizeOffset = 0;
    }

    private void Update()
    {
        UpdateCameraPosition();
        CameraZoom();
    }

    private void UpdateCameraPosition()
    {
        //This method updates the camera position to follow the player object along the x axis
        playerXPos = playerTransform.position.x;

        transform.position = new Vector3(playerXPos, 4.5f + cameraYPosOffset, -10);
        thisCamera.orthographicSize = 10 + cameraSizeOffset;
    }

    private void CameraZoom()
    {
        if (trainData.GetPlayerAboveTrain() & trainData.GetTrainSpeed() > 0)
        {
            if (!(cameraSizeOffset >= 5f))
            {
                cameraYPosOffset += 1.2f * Time.deltaTime;
                cameraSizeOffset += 1.2f * Time.deltaTime;
            }
        }

    }
}
