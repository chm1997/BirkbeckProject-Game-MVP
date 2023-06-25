using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableFuelPack : MonoBehaviour, IInteractableObject
{
    public TrainDataScriptableObject trainData;
    public void RecieveMessage(string message)
    {
        trainData.UpdateTrainFuel(100);
        GameObject.Destroy(gameObject);
    }
}
