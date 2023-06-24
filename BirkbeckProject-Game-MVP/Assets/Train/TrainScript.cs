using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainScript : MonoBehaviour
{
    public TrainDataScriptableObject trainData;

    void Awake()
    {
        TrainDataSetUp();   
    }

    private void TrainDataSetUp()
    {
        trainData.SetMaxTrainFuel(1000);
        trainData.SetTrainFuel(1000);

        trainData.SetMaxTrainHealth(1000);
        trainData.SetTrainHealth(1000);

        trainData.SetMaxTrainSpeed(100);
        trainData.SetTrainSpeed(0);
    }
}
