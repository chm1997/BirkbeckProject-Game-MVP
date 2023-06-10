using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDAmmoScript : MonoBehaviour
{
    private int _triangleJumpAmmo;
    private TMP_Text textObject;
    private string textString;

    private void Start()
    {
        textObject = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        var triangle = GameObject.Find("Triangle");
        PlayerScript ps = triangle.GetComponent<PlayerScript>();
        _triangleJumpAmmo = ps.GetJumpAmmo();

        textString = "Ammo: " + _triangleJumpAmmo.ToString();

        textObject.text = textString;
    }
}
