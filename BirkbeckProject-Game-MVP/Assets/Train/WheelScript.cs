using UnityEngine;

public class WheelScript : MonoBehaviour
{
    /// <summary>
    /// This class rotates attached wheel object to give a sense of motion
    /// TrainDataScriptableObject trainData: a Scriptable Object containing an float variable representing train data
    /// </summary>

    [SerializeField]
    internal TrainDataScriptableObject trainData;

    private Vector3 rotateVector;
    private float trainSpeed;

    private void Update()
    {
        trainSpeed = trainData.GetTrainSpeed();
        float rotationVar = trainSpeed * 20 * -1 * Time.deltaTime;
        rotateVector = new Vector3(0, 0, rotationVar);
        transform.Rotate(rotateVector);
    }
}
