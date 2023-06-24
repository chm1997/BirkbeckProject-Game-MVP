using UnityEngine;

public class InteractableTrainSteeringWheel : MonoBehaviour, IInteractableObject
{
    public bool isOn = false;
    public TrainDataScriptableObject trainData;

    public void RecieveMessage(string message)
    {
        if (isOn)
        {
            trainData.SetTrainSpeed(0); 
            isOn = false;
        }
        else
        {
            trainData.SetTrainSpeed(50);
            isOn = true;
        }
    }
}
