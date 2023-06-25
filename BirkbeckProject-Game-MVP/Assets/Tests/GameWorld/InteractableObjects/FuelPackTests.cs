using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class FuelPackTests
{
    GameObject packPrefab = Resources.Load<GameObject>("FuelPack");
    GameObject pack;
    InteractableFuelPack packScript;

    [UnitySetUp]
    public IEnumerator HealthPackTestTest_Setup()
    {
        pack = GameObject.Instantiate(packPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        packScript = pack.GetComponent<InteractableFuelPack>();
        yield return null;
    }

    [TearDown]
    public void HealthPackTest_TearDown()
    {
        Object.Destroy(pack);
        Object.Destroy(packScript);
    }

    [UnityTest]
    public IEnumerator HealthPackTest_UpdatesFuelOnMessage()
    {
        packScript.trainData.SetTrainFuel(2);
        pack.SendMessage("RecieveMessage", "");
        yield return null;
        Assert.Greater(packScript.trainData.GetTrainFuel(), 2);
    }

    [UnityTest]
    public IEnumerator HealthPackTest_DestroyedAfterInteraction()
    {
        pack.SendMessage("RecieveMessage", "");
        yield return null;
        Assert.AreEqual(pack.ToString(), "null");
    }
}
