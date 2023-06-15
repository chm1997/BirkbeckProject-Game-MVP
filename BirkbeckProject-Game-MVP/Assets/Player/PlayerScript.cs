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

    private Rigidbody2D rb2D;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        playerHealth.SetPlayerHealth(5);
        playerAmmo.SetPlayerAmmo(3);
    }

    private void OnTriggerEnter2D(Collider2D Other)
    {
        playerHealth.UpdatePlayerHealth(-1);
    }
}