using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDHealthScript : MonoBehaviour
{
    private int _triangleHealth;
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
        _triangleHealth = ps.GetHealth();

        textString = "Health: " + _triangleHealth.ToString();

        textObject.text = textString;
    }
}
