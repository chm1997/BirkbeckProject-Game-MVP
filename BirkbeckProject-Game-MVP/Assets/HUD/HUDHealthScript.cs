using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDHealthScript : MonoBehaviour
{
    public PlayerHealth playerHealth;
    private TMP_Text textObject;
    private string textString;

    private void Start()
    {
        textObject = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        int currentHealth = playerHealth.GetPlayerHealth();
        textString = "Health: " + currentHealth.ToString();
        textObject.text = textString;
    }
}
