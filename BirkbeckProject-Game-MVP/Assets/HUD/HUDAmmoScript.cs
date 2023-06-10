using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDAmmoScript : MonoBehaviour
{
    private int _triangleJumpAmmo;
    public TMP_Text textObject;
    private string textString;

    // Start is called before the first frame update
    void Start()
    {
        textObject = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        var triangle = GameObject.Find("Triangle");
        PlayerScript ps = triangle.GetComponent<PlayerScript>();
        _triangleJumpAmmo = ps.GetJumpAmmo();

        textString = "Ammo: " + _triangleJumpAmmo.ToString();

        textObject.text = textString;
    }
}
