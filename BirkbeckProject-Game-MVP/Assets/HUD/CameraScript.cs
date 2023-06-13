using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private void Update()
    {
        GameObject player = GameObject.FindWithTag("Player");
        float playerXPos = player.transform.position.x;
        float playerYPos = player.transform.position.y + 5;

        transform.position = new Vector3(playerXPos, playerYPos, -10);
    }
}
