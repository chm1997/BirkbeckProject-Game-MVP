using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairScript : MonoBehaviour
{
    public PlayerInputs playerInputs;

    // Start is called before the first frame update
    void Start()
    {
        playerInputs = GameObject.FindWithTag("Player").GetComponentInParent<PlayerMovement>().playerInputs;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
