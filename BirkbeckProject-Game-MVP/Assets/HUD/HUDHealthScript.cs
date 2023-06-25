using UnityEngine;
using TMPro;

public class HUDHealthScript : MonoBehaviour
{
    /// <summary>
    /// This class displays a text based on a variable representing a health ScriptableObject
    /// Required fields:
    /// PlayerHealthScriptableObject playerHealth: a Scriptable Object containing an int variable representing player health
    /// TMP_Text textObject: A text object used to display words on screen
    /// </summary>

    [SerializeField]
    internal PlayerHealth playerHealth;
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
        // This method updates the text object to match the playerHealth object
        currentHealth = playerHealth.GetPlayerHealth();
        textString = "Health: " + currentHealth.ToString();
        textObject.text = textString;
    }
}