using UnityEngine;

public class Roadblock : MonoBehaviour, IInteractableObject
{
    /// <summary>
    /// This class stops the movement of the train object when within a certain distance from the object it's attached to
    /// Required Fields:
    /// TrainDataScriptableObject trainData: a Scriptable Object containing an float variable representing train data
    /// </summary>

    [SerializeField]
    internal TrainDataScriptableObject trainData;

    private GameObject train;

    private Vector2 trainPos;

    public void RecieveMessage(string message)
    {
        if (trainData.GetPlayerAboveTrain() == false) GameObject.Destroy(gameObject);
    }

    private void Start()
    {
        // Set up variables required for class functionality
        train = GameObject.FindWithTag("Train");
    }

    private void LateUpdate()
    {
        trainPos = train.transform.position;
        StopTrain();
    }

    private void StopTrain()
    {
        // This method stops all train movement (and fuel consumption) when nearby attached game object
        if (Mathf.Abs(trainPos.x - transform.position.x) <= 50) 
        {
            trainData.SetTrainSpeed(0);
        }
    }
}
