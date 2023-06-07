using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDAmmoScript : MonoBehaviour
{
    private int _triangleJumpAmmo;
    public TMP_Text textObject;
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

        // _triangleJumpAmmo = GetComponent<triangleJumpAmmo>();

        textObject.text = _triangleJumpAmmo.ToString();


        //GetComponent<AmmoText>().text = "GFSFDGSFD";

        //TextMeshPro mText = gameObject.GetComponent<TextMeshPro>();
    }
}
