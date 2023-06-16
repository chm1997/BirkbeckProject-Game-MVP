using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    /// <summary>
    /// This class represents the player objects general states and behaviours
    /// Required Fields:
    /// PlayerHealth playerHealth: a Scriptable Object containing an int variable representing player health
    /// PlayerAmmo playerAmmo: a Scriptable Object containing an int variable representing player ammo
    /// </summary>

    public PlayerHealth playerHealth;
    public PlayerAmmo playerAmmo;

    private void Awake()
    {
        playerHealth.SetPlayerHealth(5);
        playerAmmo.SetPlayerAmmo(3);
    }

    private void OnTriggerEnter2D(Collider2D Other)
    {
        playerHealth.UpdatePlayerHealth(-1);
    }
}