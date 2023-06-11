using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDAmmoScript : MonoBehaviour
{
    public PlayerAmmo playerAmmo;
    private TMP_Text textObject;
    private string textString;

    private void Start()
    {
        textObject = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        int currentAmmo = playerAmmo.GetPlayerAmmo();
        textString = "Ammo: " + currentAmmo.ToString();
        textObject.text = textString;
    }
}
