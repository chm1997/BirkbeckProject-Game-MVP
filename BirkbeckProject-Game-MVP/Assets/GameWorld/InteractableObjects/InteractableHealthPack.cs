using UnityEngine;
public class InteractableHealthPack : MonoBehaviour, IInteractableObject
{
    /// <summary>
    /// This class revcieves input messages and increases the players health when it does. It destroys itself after a single use
    /// Required Fields:
    /// PlayerDataScriptableObject playerData: a Scriptable Object containing an int variable representing player data
    /// </summary>

    [SerializeField]
    internal PlayerDataScriptableObject playerData;
    public void RecieveMessage(string message) 
    {
        playerData.UpdatePlayerHealth(5);
        GameObject.Destroy(gameObject);
    }
}
