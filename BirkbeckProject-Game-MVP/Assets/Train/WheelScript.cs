using UnityEngine;

public class WheelScript : MonoBehaviour
{
    [SerializeField]
    internal TrainDataScriptableObject trainData;

    public Vector3 rotateVector;

    private void Update()
    {
        float rotationVar = -20 * Time.deltaTime;
        rotateVector = new Vector3(0, 0, rotationVar);
        if (trainData.GetTrainSpeed() > 0) transform.Rotate(rotateVector);
    }
}
