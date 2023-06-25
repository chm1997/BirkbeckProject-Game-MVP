using UnityEngine;

public class InteractableTrainSteeringWheel : MonoBehaviour, IInteractableObject
{
    /// <summary>
    /// This class takes incoming messages and cycles the speed of the train object between off and on (with two different speeds)
    /// Required Fields:
    /// TrainDataScriptableObject trainData: a Scriptable Object containing various data related to the train object
    /// </summary>
    
    [SerializeField]
    internal TrainDataScriptableObject trainData;

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