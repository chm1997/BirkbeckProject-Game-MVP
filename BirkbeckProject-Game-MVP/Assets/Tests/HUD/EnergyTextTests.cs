using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using TMPro;

public class EnergyTextTests
{
    GameObject EnergyTextPrefab = Resources.Load<GameObject>("Energy Text");
    GameObject energyText;

    [UnitySetUp]
    public IEnumerator EnergyTextTest_Setup()
    {
        energyText = GameObject.Instantiate(EnergyTextPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        yield return null;
    }

    [TearDown]
    public void EnergyTextTest_TearDown()
    {
        Object.Destroy(energyText);
    }

    [UnityTest]
    public IEnumerator EnergyTextTests_SetTo4()
    {
        energyText.GetComponent<HUDEnergyScript>().playerEnergy.SetPlayerEnergy(4);

        yield return null;

        Assert.AreEqual("Energy: 4", energyText.GetComponent<TextMeshProUGUI>().text);
    }

    [UnityTest]
    public IEnumerator EnergyTextTests_SetTo0()
    {
        energyText.GetComponent<HUDEnergyScript>().playerEnergy.SetPlayerEnergy(0);

        yield return null;

        Assert.AreEqual("Energy: 0", energyText.GetComponent<TextMeshProUGUI>().text);
    }

    [UnityTest]
    public IEnumerator EnergyTextTests_SetTo10000()
    {
        energyText.GetComponent<HUDEnergyScript>().playerEnergy.SetPlayerEnergy(10000);

        yield return null;

        Assert.AreEqual("Energy: 10000", energyText.GetComponent<TextMeshProUGUI>().text);
    }
}
