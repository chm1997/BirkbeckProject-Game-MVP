using UnityEngine;

public class Roadblock : MonoBehaviour, IInteractableObject
{
    [SerializeField]
    internal TrainDataScriptableObject trainData;

    private GameObject train;

    Vector2 trainPos;

    public void RecieveMessage(string message)
    {
        GameObject.Destroy(gameObject);
    }

    private void Start()
    {
        train = GameObject.FindWithTag("Train");
    }

    private void LateUpdate()
    {
        trainPos = train.transform.position;
        StopTrain();
    }

    private void StopTrain()
    {
        if (Mathf.Abs(trainPos.x - transform.position.x) <= 50) 
        {
            trainData.SetTrainSpeed(0);
        }
    }
}
