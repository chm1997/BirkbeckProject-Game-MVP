using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    /// <summary>
    /// This class represents the player objects general states and behaviours
    /// Required Fields:
    /// PlayerHealth playerHealth: a Scriptable Object containing an int variable representing player health
    /// PlayerEnergy playerEnergy: a Scriptable Object containing an int variable representing player energy
    /// </summary>

    public PlayerHealth playerHealth;
    public PlayerEnergy playerEnergy;

    private void Awake()
    {
        playerHealth.SetPlayerHealth(5);
        playerEnergy.SetPlayerEnergy(100);
    }
    private void LateUpdate()
    {
        if (playerEnergy.GetPlayerEnergy() < playerEnergy.GetMaxEnergy()) playerEnergy.UpdatePlayerEnergy(1);
    }

    private void OnTriggerEnter2D(Collider2D Other)
    {
        playerHealth.UpdatePlayerHealth(-1);
    }
}