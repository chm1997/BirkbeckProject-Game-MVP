using UnityEngine;

public class InteractableTrainSteeringWheel : MonoBehaviour, IInteractableObject
{
    public TrainDataScriptableObject trainData;

    public void RecieveMessage(string message)
    {
        if (trainData.GetTrainSpeed() > 0)
        {
            trainData.SetTrainSpeed(0);
        }
        else
        {
            trainData.SetTrainSpeed(30);
        }
    }
}