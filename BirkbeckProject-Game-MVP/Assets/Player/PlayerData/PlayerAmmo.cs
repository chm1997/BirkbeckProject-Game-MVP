using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerAmmo", menuName = "Player Ammo", order = 102)]
public class PlayerAmmo : ScriptableObject
{
    [SerializeField]
    private int playerAmmo;

    public int GetPlayerAmmo()
    {
        return playerAmmo;
    }
    public void SetPlayerAmmo(int incomingAmmo)
    {
        playerAmmo = incomingAmmo;
    }
    public void UpdatePlayerAmmo(int incomingChange)
    {
        playerAmmo += incomingChange;
    }
}