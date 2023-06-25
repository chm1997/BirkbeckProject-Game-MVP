using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using TMPro;

public class FuelTextTests
{
    GameObject fuelTextPrefab = Resources.Load<GameObject>("Fuel Text Variant");
    GameObject fuelText;

    [UnitySetUp]
    public IEnumerator FuelTextTest_Setup()
    {
        fuelText = GameObject.Instantiate(fuelTextPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        yield return null;
    }

    [TearDown]
    public void FuelTextTest_TearDown()
    {
        Object.Destroy(fuelText);
    }

    [UnityTest]
    public IEnumerator FuelTextTests_SetTo5()
    {
        fuelText.GetComponent<HUDFuelScript>().trainData.SetTrainFuel(5);

        yield return null;

        Assert.AreEqual("Fuel: 5", fuelText.GetComponent<TextMeshProUGUI>().text);
    }

    [UnityTest]
    public IEnumerator FuelTextTests_SetTo2()
    {
        fuelText.GetComponent<HUDFuelScript>().trainData.SetTrainFuel(2);

        yield return null;

        Assert.AreEqual("Fuel: 2", fuelText.GetComponent<TextMeshProUGUI>().text);
    }

    [UnityTest]
    public IEnumerator FuelTextTests_SetTo100()
    {
        fuelText.GetComponent<HUDFuelScript>().trainData.SetTrainFuel(100);

        yield return null;

        Assert.AreEqual("Fuel: 100", fuelText.GetComponent<TextMeshProUGUI>().text);
    }
}
