using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerData", menuName = "Player Data", order = 102)]
public class PlayerDataScriptableObject : ScriptableObject
{
    private int playerHealth;
    private int maxHealth = 15;

    private float playerEnergy;
    private int maxEnergy = 100;

    public int GetPlayerHealth()
    {
        return playerHealth;
    }
    public void SetPlayerHealth(int incomingChange)
    {
        playerHealth = incomingChange;
    }
    public void UpdatePlayerHealth(int incomingChange)
    {
        playerHealth += incomingChange;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public void SetMaxHealth(int incomingChange)
    {
        maxHealth = incomingChange;
    }


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