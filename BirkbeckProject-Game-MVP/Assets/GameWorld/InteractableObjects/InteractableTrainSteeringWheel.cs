using UnityEngine;

public class InteractableTrainSteeringWheel : MonoBehaviour, IInteractableObject
{
    public bool isOn = false;
    public TrainDataScriptableObject trainData;

    public void RecieveMessage(string message)
    {

    }
}
