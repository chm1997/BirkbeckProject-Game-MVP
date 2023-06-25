using UnityEngine;
public class InteractableHealthPack : MonoBehaviour, IInteractableObject
{
    /// <summary>
    /// This class revcieves input messages and increases the players health when it does. It destroys itself after a single use
    /// Required Fields:
    /// PlayerHealth playerHealth: a Scriptable Object containing an int variable representing player health
    /// </summary>
    
    [SerializeField]
    internal PlayerHealth playerHealth;
    public void RecieveMessage(string message) 
    {
        playerHealth.UpdatePlayerHealth(5);
        GameObject.Destroy(gameObject);
    }
}
