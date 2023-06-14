using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using TMPro;

public class HealthTextTests
{
    GameObject healthTextPrefab = Resources.Load<GameObject>("Health Text");
    GameObject healthText;

    [UnitySetUp]
    public IEnumerator HealthTextTest_Setup()
    {
        healthText = GameObject.Instantiate(healthTextPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        yield return null;
    }

    [TearDown]
    public void HealthTextTest_TearDown()
    {
        UnityEngine.Object.Destroy(healthText);
    }

    [UnityTest]
    public IEnumerator HealthTextTests_SetTo5()
    {
        healthText.GetComponent<HUDHealthScript>().playerHealth.SetPlayerHealth(5);

        yield return null;

        Assert.AreEqual("Health: 5", healthText.GetComponent<TextMeshProUGUI>().text);
    }

    [UnityTest]
    public IEnumerator HealthTextTests_SetTo2()
    {
        healthText.GetComponent<HUDHealthScript>().playerHealth.SetPlayerHealth(2);

        yield return null;

        Assert.AreEqual("Health: 2", healthText.GetComponent<TextMeshProUGUI>().text);
    }

    [UnityTest]
    public IEnumerator HealthTextTests_SetTo100()
    {
        healthText.GetComponent<HUDHealthScript>().playerHealth.SetPlayerHealth(100);

        yield return null;

        Assert.AreEqual("Health: 100", healthText.GetComponent<TextMeshProUGUI>().text);
    }
}
