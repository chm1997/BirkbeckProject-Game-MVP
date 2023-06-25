using UnityEngine;
public class InteractableHealthPack : MonoBehaviour, IInteractableObject
{
    public PlayerHealth playerHealth;
    public void RecieveMessage(string message) 
    {
        playerHealth.UpdatePlayerHealth(5);
        GameObject.Destroy(gameObject);
    }
}
