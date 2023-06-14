using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using TMPro;

public class AmmoTextTests
{
    GameObject ammoTextPrefab = Resources.Load<GameObject>("Ammo Text");
    GameObject ammoText;

    [UnitySetUp]
    public IEnumerator AmmoTextTest_Setup()
    {
        ammoText = GameObject.Instantiate(ammoTextPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        yield return null;
    }

    [TearDown]
    public void AmmoTextTest_TearDown()
    {
        UnityEngine.Object.Destroy(ammoText);
    }

    [UnityTest]
    public IEnumerator AmmoTextTests_SetTo4()
    {
        ammoText.GetComponent<HUDAmmoScript>().playerAmmo.SetPlayerAmmo(4);

        yield return null;

        Assert.AreEqual("Ammo: 4", ammoText.GetComponent<TextMeshProUGUI>().text);
    }

    [UnityTest]
    public IEnumerator AmmoTextTests_SetTo0()
    {
        ammoText.GetComponent<HUDAmmoScript>().playerAmmo.SetPlayerAmmo(0);

        yield return null;

        Assert.AreEqual("Ammo: 0", ammoText.GetComponent<TextMeshProUGUI>().text);
    }

    [UnityTest]
    public IEnumerator AmmoTextTests_SetTo10000()
    {
        ammoText.GetComponent<HUDAmmoScript>().playerAmmo.SetPlayerAmmo(10000);

        yield return null;

        Assert.AreEqual("Ammo: 10000", ammoText.GetComponent<TextMeshProUGUI>().text);
    }
}
