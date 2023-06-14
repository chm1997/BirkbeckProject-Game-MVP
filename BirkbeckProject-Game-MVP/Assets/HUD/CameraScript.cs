using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Transform playerTransform;
    private void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {    
        float playerXPos = playerTransform.position.x;
        float playerYPos = playerTransform.position.y + 5;

        transform.position = new Vector3(playerXPos, playerYPos, -10);
    }
}
