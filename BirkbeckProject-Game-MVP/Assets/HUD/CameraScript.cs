using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private void Start()
    {
        transform.Translate(3, 1, -10);
    }

    private void Update()
    {
        var player = GameObject.Find("Player");
        float playerXPos = player.transform.position.x;
        float playerYPos = player.transform.position.y + 5;

        transform.position = new Vector3(playerXPos, playerYPos, -10);
    }
}
