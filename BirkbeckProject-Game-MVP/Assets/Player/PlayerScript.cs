using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    /// <summary>
    /// This class represents the player objects' general states and behaviours
    /// Required Fields:
    /// PlayerHealth playerHealth: a Scriptable Object containing an int variable representing player health
    /// PlayerEnergy playerEnergy: a Scriptable Object containing an int variable representing player energy
    /// </summary>

    [SerializeField]
    internal PlayerHealth playerHealth;
    [SerializeField]
    internal PlayerEnergy playerEnergy;

    private float energyRegenVariable;

    private void Awake()
    {
        // Set up variables required for class functionality
        playerHealth.SetPlayerHealth(5);
        playerEnergy.SetPlayerEnergy(100);
        energyRegenVariable = 5f;
    }

    private void LateUpdate()
    {
        UpdatePlayerEnergyIfNotAtMax();
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

    private void UpdatePlayerEnergyIfNotAtMax()
    {
        // This method works slowly gets the player energy variable held in the associated scriptable object up to its set max
        if (playerEnergy.GetPlayerEnergy() < playerEnergy.GetMaxEnergy())
        {
            playerEnergy.UpdatePlayerEnergy(energyRegenVariable * Time.deltaTime);
        }
    }
}