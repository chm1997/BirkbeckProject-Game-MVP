using System.Collections;
using System.Collections.Generic;
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
    public void SetPlayerHealth(int incomingHealth)
    {
        playerHealth = incomingHealth;
    }
    public void UpdatePlayerHealth(int incomingChange)
    {
        playerHealth += incomingChange;
    }
}