using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        transform.Translate(3, 1, -10);
    }


    // Update is called once per frame
    void Update()
    {
        var triangle = GameObject.Find("Triangle");
        float triangleXPos = triangle.transform.position.x;
        float triangleYPos = triangle.transform.position.y + 5;

        transform.position = new Vector3(triangleXPos, triangleYPos, -10);
    }
}
