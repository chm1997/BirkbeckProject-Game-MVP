using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDHealthScript : MonoBehaviour
{
    private int _triangleHealth;
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
        _triangleHealth = ps.GetHealth();

        textString = "Health: " + _triangleHealth.ToString();

        textObject.text = textString;
    }
}
