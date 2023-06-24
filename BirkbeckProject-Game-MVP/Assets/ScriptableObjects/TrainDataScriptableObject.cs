using UnityEngine;

[CreateAssetMenu(fileName = "New TrainData", menuName = "Train Data", order = 102)]
public class TrainDataScriptableObject : ScriptableObject
{
    public int trainSpeed;
    private int maxTrainSpeed;

    private int trainFuel;
    private int maxTrainFuel;

    private int trainHealth;
    private int maxTrainHealth;

    public int GetTrainSpeed()
    {
        return trainSpeed;
    }
    public void SetTrainSpeed(int incomingHealth)
    {
        trainSpeed = incomingHealth;
    }
    public void UpdateTrainSpeed(int incomingChange)
    {
        trainSpeed += incomingChange;
    }

    public int GetMaxTrainSpeed()
    {
        return maxTrainSpeed;
    }
    public void SetMaxTrainSpeed(int incomingHealth)
    {
        maxTrainSpeed = incomingHealth;
    }
    public void UpdateMaxTrainSpeed(int incomingChange)
    {
        maxTrainSpeed += incomingChange;
    }

    public int GetTrainFuel()
    {
        return trainFuel;
    }
    public void SetTrainFuel(int incomingHealth)
    {
        trainFuel = incomingHealth;
    }
    public void UpdateTrainFuel(int incomingChange)
    {
        trainFuel += incomingChange;
    }

    public int GetMaxTrainFuel()
    {
        return maxTrainFuel;
    }
    public void SetMaxTrainFuel(int incomingHealth)
    {
        maxTrainFuel = incomingHealth;
    }
    public void UpdateMaxTrainFuel(int incomingChange)
    {
        maxTrainFuel += incomingChange;
    }

    public int GetTrainHealth()
    {
        return trainHealth;
    }
    public void SetTrainHealth(int incomingHealth)
    {
        trainHealth = incomingHealth;
    }
    public void UpdateTrainHealth(int incomingChange)
    {
        trainHealth += incomingChange;
    }

    public int GetMaxTrainHealth()
    {
        return maxTrainHealth;
    }
    public void SetMaxTrainHealth(int incomingHealth)
    {
        maxTrainHealth = incomingHealth;
    }
    public void UpdateMaxTrainHealth(int incomingChange)
    {
        maxTrainHealth += incomingChange;
    }
}
