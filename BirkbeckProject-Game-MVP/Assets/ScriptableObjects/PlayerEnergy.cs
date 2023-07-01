using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerEnergy", menuName = "Player Energy", order = 102)]
public class PlayerEnergy : ScriptableObject
{
    [SerializeField]
    private float playerEnergy;
    [SerializeField]
    private int maxEnergy = 100;

    public float GetPlayerEnergy()
    {
        return playerEnergy;
    }
    public void SetPlayerEnergy(float incomingChange)
    {
        playerEnergy = incomingChange;
    }
    public void UpdatePlayerEnergy(float incomingChange)
    {
        playerEnergy += incomingChange;
    }

    public int GetMaxEnergy()
    {
        return maxEnergy;
    }

    public void SetMaxEnergy(int incomingChange)
    {
        maxEnergy = incomingChange;
    }

}