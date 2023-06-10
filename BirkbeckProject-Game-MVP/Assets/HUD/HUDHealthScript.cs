using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDHealthScript : MonoBehaviour
{
    private int playerHealth;
    private TMP_Text textObject;
    private string textString;

    private void Start()
    {
        textObject = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        var player = GameObject.Find("Player");
        PlayerScript ps = player.GetComponent<PlayerScript>();
        playerHealth = ps.GetHealth();

        textString = "Health: " + playerHealth.ToString();

        textObject.text = textString;
    }
}
