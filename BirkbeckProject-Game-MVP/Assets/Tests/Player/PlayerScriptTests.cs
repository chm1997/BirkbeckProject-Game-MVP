using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerScriptTests
{
    GameObject playerPrefab = Resources.Load<GameObject>("Player");
    PlayerScript playerScript;

    [SetUp]
    public void PlayerScriptTest_Setup()
    {
        playerScript = GameObject.Instantiate(playerPrefab, new Vector3(10, 10, 0), Quaternion.identity).GetComponent<PlayerScript>();
       
    }

    [TearDown]
    public void PlayerScriptTest_TearDown()
    {
        Object.Destroy(playerScript);
    }

    [UnityTest]
    public IEnumerator PlayerScriptTest_Energy100AtStart()
    {
        Assert.AreEqual(100, playerScript.playerEnergy.GetPlayerEnergy());
        yield return null;
    }

    [UnityTest]
    public IEnumerator PlayerScriptTest_Health5AtStart()
    {
        Assert.AreEqual(5, playerScript.playerHealth.GetPlayerHealth());
        yield return null;
    }

    [UnityTest]
    public IEnumerator PlayerScriptTest_HealthDecreases()
    {
        var collisionTestObject = new GameObject().AddComponent<BoxCollider2D>();
        collisionTestObject.isTrigger = true;
        collisionTestObject.transform.position = new Vector3(10, 10, 0);

        yield return new WaitForSeconds(0.2f);

        Assert.AreEqual(4, playerScript.playerHealth.GetPlayerHealth());
    }

    [UnityTest]
    public IEnumerator PlayerScriptTest_EnergyIncreasesOverTime()
    {
        playerScript.playerEnergy.SetPlayerEnergy(50);

        yield return new WaitForSeconds(0.2f);

        Assert.Greater(playerScript.playerEnergy.GetPlayerEnergy(), 50);
    }

    [UnityTest]
    public IEnumerator PlayerScriptTest_EnergyIncreasesOverTimeStopsAt100()
    {
        playerScript.playerEnergy.SetPlayerEnergy(100);

        yield return new WaitForSeconds(0.2f);

        Assert.AreEqual(playerScript.playerEnergy.GetPlayerEnergy(), 100);
    }
}
