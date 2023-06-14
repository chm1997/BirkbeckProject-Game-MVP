using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDAmmoScript : MonoBehaviour
{
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
