using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDAmmoScript : MonoBehaviour
{
    private int playerJumpAmmo;
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
        playerJumpAmmo = ps.GetJumpAmmo();

        textString = "Ammo: " + playerJumpAmmo.ToString();

        textObject.text = textString;
    }
}
