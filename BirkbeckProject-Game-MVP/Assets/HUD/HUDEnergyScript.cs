using UnityEngine;
using TMPro;

public class HUDEnergyScript : MonoBehaviour
{
    /// <summary>
    /// This class displays a text based on a variable representing an energy ScriptableObject
    /// Required fields:
    /// PlayerEnergyScriptableObject playerEnergy: a Scriptable Object containing an int variable representing player energy
    /// TMP_Text textObject: A text object used to display words on screen
    /// </summary>

    public PlayerEnergy playerEnergy;
    public TMP_Text textObject;
    private string textString;
    private float currentEnergy;

    private void Update()
    {
        currentEnergy = playerEnergy.GetPlayerEnergy();
        textString = "Energy: " + ((int)(currentEnergy)).ToString();
        textObject.text = textString;
    }
}
