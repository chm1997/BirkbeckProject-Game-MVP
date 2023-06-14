using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using TMPro;

public class AmmoTextTests
{
    GameObject ammoTextPrefab = Resources.Load<GameObject>("Health Text");
    GameObject ammoText;

    //GameObject dssadfs = Resources.Load<GameObject>("PlayerHealthScriptableObject");


    [SetUp]
    public void AmmoTextTest_Setup()
    {
        ammoText = GameObject.Instantiate(ammoTextPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

    [TearDown]
    public void AmmoTextTest_TearDown()
    {
        UnityEngine.Object.Destroy(ammoText);
    }

    [UnityTest]
    public IEnumerator AmmoTextTest_StartsWith5()
    {
        yield return null;

        Assert.AreEqual("Health: 5", ammoText.GetComponent<TextMeshProUGUI>().text);
    }

    [UnityTest]
    public IEnumerator AmmoTextTest_DecreasesWithHealthVariable()
    {
        yield return null;

        //HUDHealthScript hudHealthScript = healthText.GetComponent<HUDHealthScript>();
        //Debug.Log(ammoText.GetComponent<HUDAmmoScript>());

        //newPart.AddComponent<HUDHealthScript>();


        //var sut = dssadfs.CreateInstance<PlayerHealthScriptableObject>();
        //Debug.Log(sut);

        Component[] components = ammoText.GetComponents(typeof(Component));
        foreach (Component component in components)
        {
            Debug.Log(component.ToString());
        }
    }
}