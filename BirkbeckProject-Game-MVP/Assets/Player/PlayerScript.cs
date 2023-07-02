using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    /// <summary>
    /// This class represents the player objects' general states and behaviours
    /// Required Fields:
    /// PlayerDataScriptableObject playerData: a Scriptable Object containing an int variable representing player data
    /// </summary>

    [SerializeField]
    internal PlayerDataScriptableObject playerData;

    private float energyRegenVariable;

    private void Awake()
    {
        // Set up variables required for class functionality
        playerData.SetPlayerHealth(5);
        playerData.SetPlayerEnergy(100);
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
                playerData.UpdatePlayerHealth(Other.GetComponent<IDamagingObject>().damageValue * -1) ;
            }
        }
    }

    private void UpdatePlayerEnergyIfNotAtMax()
    {
        // This method works slowly gets the player energy variable held in the associated scriptable object up to its set max
        if (playerData.GetPlayerEnergy() < playerData.GetMaxEnergy())
        {
            playerData.UpdatePlayerEnergy(energyRegenVariable * Time.deltaTime);
        }
    }
}