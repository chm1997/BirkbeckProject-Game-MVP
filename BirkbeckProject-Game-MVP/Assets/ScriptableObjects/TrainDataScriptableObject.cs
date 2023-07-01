using UnityEngine;

[CreateAssetMenu(fileName = "New TrainData", menuName = "Train Data", order = 102)]
public class TrainDataScriptableObject : ScriptableObject
{
    private float trainSpeed = 0;
    private float maxTrainSpeed;

    private float trainFuel;
    private float maxTrainFuel;

    private float trainHealth;
    private float maxTrainHealth;

    private bool playerInTrain;
    private bool playerAboveTrain;

    public float GetTrainSpeed()
    {
        return trainSpeed;
    }
    public void SetTrainSpeed(float incomingChange)
    {
        trainSpeed = incomingChange;
    }
    public void UpdateTrainSpeed(float incomingChange)
    {
        trainSpeed += incomingChange;
    }

    public float GetMaxTrainSpeed()
    {
        return maxTrainSpeed;
    }
    public void SetMaxTrainSpeed(float incomingChange)
    {
        maxTrainSpeed = incomingChange;
    }

    public float GetTrainFuel()
    {
        return trainFuel;
    }
    public void SetTrainFuel(float incomingChange)
    {
        trainFuel = incomingChange;
    }
    public void UpdateTrainFuel(float incomingChange)
    {
        trainFuel += incomingChange;
    }

    public float GetMaxTrainFuel()
    {
        return maxTrainFuel;
    }
    public void SetMaxTrainFuel(float incomingChange)
    {
        maxTrainFuel = incomingChange;
    }

    public float GetTrainHealth()
    {
        return trainHealth;
    }
    public void SetTrainHealth(float incomingChange)
    {
        trainHealth = incomingChange;
    }
    public void UpdateTrainHealth(float incomingChange)
    {
        trainHealth += incomingChange;
    }

    public float GetMaxTrainHealth()
    {
        return maxTrainHealth;
    }
    public void SetMaxTrainHealth(float incomingChange)
    {
        maxTrainHealth = incomingChange;
    }

    public bool GetPlayerInTrain()
    {
        return playerInTrain;
    }

    public void SetPlayerInTrain(bool incomingBool)
    {
        playerInTrain = incomingBool;
    }

    public bool GetPlayerAboveTrain()
    {
        return playerAboveTrain;
    }

    public void SetPlayerAboveTrain(bool incomingBool)
    {
        playerAboveTrain = incomingBool;
    }
}
