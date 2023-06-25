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
    public float energyRegenVariable;

    private void Awake()
    {
        playerHealth.SetTrainFuel(5);
        playerEnergy.SetPlayerEnergy(100);
        energyRegenVariable = 5f;
    }

    private void LateUpdate()
    {
        if (playerEnergy.GetPlayerEnergy() < playerEnergy.GetMaxEnergy())
        {
            playerEnergy.UpdatePlayerEnergy(energyRegenVariable * Time.deltaTime); 
        }
    }

    private void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.GetComponent<IDamagingObject>() != null)
        {
            if (Other.GetComponent<IDamagingObject>().isDamaging)
            {
                playerHealth.UpdatePlayerHealth(Other.GetComponent<IDamagingObject>().damageValue * -1) ;
            }
        }
    }
}