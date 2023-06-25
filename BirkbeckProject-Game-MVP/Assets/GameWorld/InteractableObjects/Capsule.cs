using UnityEngine;

public class Capsule : MonoBehaviour, IDamagingObject
{
    /// <summary>
    /// This class is an example of a damaging object implementation
    /// Required Fields:
    /// bool isDamaging: allows the damaging nature of the object to be turned on and off
    /// int damageValue: determines how much damage is dealt to the player
    /// </summary>
    
    public bool isDamaging { get; set; }
    public int damageValue { get; set; }

    private void Start()
    {
        // Set up variables required for class functionality
        isDamaging = true;
        damageValue = 1;
    }
}
