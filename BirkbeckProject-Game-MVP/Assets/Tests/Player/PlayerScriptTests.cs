using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerScriptTests
{
    GameObject playerPrefab = Resources.Load<GameObject>("Player");

    GameObject player;

    [SetUp]
    public void PlayerScriptTest_Setup()
    {
        player = GameObject.Instantiate(playerPrefab, new Vector3(10, 10, 0), Quaternion.identity);
    }

    [TearDown]
    public void PlayerScriptTest_TearDown()
    {
        Object.Destroy(player);
    }

    [UnityTest]
    public IEnumerator PlayerScriptTest_Energy100AtStart()
    {
        Assert.AreEqual(100, player.GetComponent<PlayerScript>().playerEnergy.GetPlayerEnergy());
        yield return null;
    }

    [UnityTest]
    public IEnumerator PlayerScriptTest_Health5AtStart()
    {
        Assert.AreEqual(5, player.GetComponent<PlayerScript>().playerHealth.GetPlayerHealth());
        yield return null;
    }

    [UnityTest]
    public IEnumerator PlayerScriptTest_HealthDecreases()
    {
        var collisionTestObject = new GameObject().AddComponent<BoxCollider2D>();
        collisionTestObject.isTrigger = true;
        collisionTestObject.transform.position = new Vector3(10, 10, 0);

        yield return new WaitForSeconds(0.2f);

        Assert.AreEqual(4, player.GetComponent<PlayerScript>().playerHealth.GetPlayerHealth());
    }
}
