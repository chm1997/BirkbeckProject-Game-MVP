using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerScriptTests
{
    GameObject playerPrefab = Resources.Load<GameObject>("Player");
    PlayerScript player;

    [SetUp]
    public void PlayerScriptTest_Setup()
    {
        player = GameObject.Instantiate(playerPrefab, new Vector3(10, 10, 0), Quaternion.identity).GetComponent<PlayerScript>();
    }

    [TearDown]
    public void PlayerScriptTest_TearDown()
    {
        Object.Destroy(player);
    }

    [UnityTest]
    public IEnumerator PlayerScriptTest_HealthDecreases()
    {
        var collisionTestObject = new GameObject();
        collisionTestObject.AddComponent<BoxCollider2D>();
        collisionTestObject.AddComponent<Capsule>();
        collisionTestObject.GetComponent<BoxCollider2D>().isTrigger = true;
        collisionTestObject.transform.position = new Vector3(10, 10, 0);

        yield return new WaitForSeconds(0.2f);

        Assert.AreEqual(4, player.playerData.GetPlayerHealth());
    }

    [UnityTest]
    public IEnumerator PlayerScriptTest_EnergyIncreasesOverTime()
    {
        player.playerData.SetMaxEnergy(100);
        player.playerData.SetPlayerEnergy(50);

        yield return new WaitForSeconds(1f);

        Assert.Greater(player.playerData.GetPlayerEnergy(), 50);
    }

    [UnityTest]
    public IEnumerator PlayerScriptTest_EnergyIncreasesOverTimeStopsAtMax()
    {
        player.playerData.SetMaxEnergy(100);
        player.playerData.SetPlayerEnergy(100);

        yield return new WaitForSeconds(1f);

        Assert.AreEqual(player.playerData.GetPlayerEnergy(), 100);
    }
}
