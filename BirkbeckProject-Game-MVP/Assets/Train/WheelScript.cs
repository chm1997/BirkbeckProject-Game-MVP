using UnityEngine;

public class WheelScript : MonoBehaviour
{
    [SerializeField]
    internal TrainDataScriptableObject trainData;

    private Vector3 rotateVector;
    private float trainSpeed;

    private void Update()
    {
        trainSpeed = trainData.GetTrainSpeed();
        float rotationVar = trainSpeed * -1 * Time.deltaTime;
        rotateVector = new Vector3(0, 0, rotationVar);
        transform.Rotate(rotateVector);
    }
}
