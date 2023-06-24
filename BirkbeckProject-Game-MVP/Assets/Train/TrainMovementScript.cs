using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMovementScript : MonoBehaviour
{
    public TrainDataScriptableObject trainData;
    private Rigidbody2D rb2D;
    public float trainSpeed;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        trainSpeed = trainData.GetTrainSpeed();
        HandleTrainMovement();
    }

    private void HandleTrainMovement()
    {
        rb2D.AddForce(transform.right * trainSpeed, ForceMode2D.Impulse);
    }
}
