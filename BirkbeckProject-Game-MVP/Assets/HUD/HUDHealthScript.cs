using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDHealthScript : MonoBehaviour
{
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