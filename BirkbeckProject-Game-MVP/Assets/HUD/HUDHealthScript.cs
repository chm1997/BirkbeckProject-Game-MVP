using UnityEngine;
using TMPro;

public class HUDHealthScript : MonoBehaviour
{
    /// <summary>
    /// This class displays a text based on a variable representing a health ScriptableObject
    /// Required fields:
    /// PlayerDataScriptableObject playerData: a Scriptable Object containing an int variable representing player data
    /// TMP_Text textObject: A text object used to display words on screen
    /// </summary>

    [SerializeField]
    internal PlayerDataScriptableObject playerData;
    [SerializeField]
    internal TMP_Text textObject;

    private string textString;
    private int currentHealth;

    private void Update()
    {
        UpdateEnergyText();
    }

    private void UpdateEnergyText()
    {
        // This method updates the text object to match the playerData object
        currentHealth = playerData.GetPlayerHealth();
        textString = "Health: " + currentHealth.ToString();
        textObject.text = textString;
    }
}