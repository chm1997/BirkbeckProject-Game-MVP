using UnityEngine;

public class InteractableFuelPack : MonoBehaviour, IInteractableObject
{
    /// <summary>
    /// This class revcieves input messages and increases the trains fuel variable when it does. It destroys itself after a single use
    /// Required Fields:
    /// TrainDataScriptableObject trainData: a Scriptable Object containing various data related to the train object
    /// </summary>

    [SerializeField]
    internal TrainDataScriptableObject trainData;
    public void RecieveMessage(string message)
    {
        trainData.UpdateTrainFuel(100);
        GameObject.Destroy(gameObject);
    }
}
