using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerEnergy", menuName = "Player Energy", order = 102)]
public class PlayerEnergy : ScriptableObject
{
    [SerializeField]
    private int playerEnergy;

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
}