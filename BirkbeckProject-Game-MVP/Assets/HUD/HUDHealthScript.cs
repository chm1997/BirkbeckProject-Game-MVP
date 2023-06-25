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

    public PlayerHealth playerHealth;
    public TMP_Text textObject;
    private string textString;
    public int currentHealth;

    private void Update()
    {
        currentHealth = playerHealth.GetPlayerHealth();
        textString = "Health: " + currentHealth.ToString();
        textObject.text = textString;
    }
}