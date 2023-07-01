using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerHealth", menuName = "Player Health", order = 101)]
public class PlayerHealth : ScriptableObject
{
    [SerializeField]
    private int playerHealth;

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
}