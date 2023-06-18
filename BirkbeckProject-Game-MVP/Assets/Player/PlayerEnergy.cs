using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerEnergy", menuName = "Player Energy", order = 102)]
public class PlayerEnergy : ScriptableObject
{
    [SerializeField]
    private int playerEnergy;
    [SerializeField]
    private int maxEnergy = 100;

    public int GetPlayerEnergy()
    {
        return playerEnergy;
    }
    public void SetPlayerEnergy(int incomingEnergy)
    {
        playerEnergy = incomingEnergy;
    }
    public void UpdatePlayerEnergy(int incomingChange)
    {
        playerEnergy += incomingChange;
    }

    public int GetMaxEnergy()
    {
        return maxEnergy;
    }

    public void SetMaxEnergy(int incomingMax)
    {
        maxEnergy = incomingMax;
    }
}