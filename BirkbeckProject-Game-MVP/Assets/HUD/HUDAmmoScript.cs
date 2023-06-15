using UnityEngine;
using TMPro;

public class HUDAmmoScript : MonoBehaviour
{
    /// <summary>
    /// This class displays a text based on a variable representing an ammo ScriptableObject
    /// Required fields:
    /// PlayerAmmoScriptableObject playerAmmo: a Scriptable Object containing an int variable representing player ammo
    /// TMP_Text textObject: A text object used to display words on screen
    /// </summary>

    public PlayerAmmo playerAmmo;
    public TMP_Text textObject;
    private string textString;
    private int currentAmmo;

    private void Update()
    {
        currentAmmo = playerAmmo.GetPlayerAmmo();
        textString = "Ammo: " + currentAmmo.ToString();
        textObject.text = textString;
    }
}
