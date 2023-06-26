using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

public class WheelScriptTests
{
    GameObject trainPrefab = Resources.Load<GameObject>("TrainMainObject");
    GameObject playerPrefab = Resources.Load<GameObject>("Player");

    [SetUp]
    public void WheelScriptTest_Setup()
    {
        //Loop deletes all active game objects, required because child objects of TrainMainObject can persist
        foreach (GameObject o in Object.FindObjectsOfType<GameObject>())
        {
            GameObject.Destroy(o);
        }
    }

    [UnityTest]
    public IEnumerator WheelScriptTest_NoRotationWhenStationary()
    {
        GameObject player = GameObject.Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        GameObject train = GameObject.Instantiate(trainPrefab, new Vector3(0, 0, 0), Quaternion.identity);

        Transform wheelTransform = train.transform.Find("TrainMainSpriteObject").transform.Find("TrainWheelSpriteObject").transform.Find("WheelHolder_1").transform.Find("Wheel");

        TrainScript trainScript = train.GetComponent<TrainScript>();
        trainScript.trainData.SetTrainSpeed(0);

        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual(wheelTransform.rotation.z, 0);
    }

    [UnityTest]
    public IEnumerator WheelScriptTest_SomeRotationWhenSpeedOver0()
    {
        GameObject player = GameObject.Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        GameObject train = GameObject.Instantiate(trainPrefab, new Vector3(0, 0, 0), Quaternion.identity);

        Transform wheelTransform = train.transform.Find("TrainMainSpriteObject").transform.Find("TrainWheelSpriteObject").transform.Find("WheelHolder_1").transform.Find("Wheel");

        TrainScript trainScript = train.GetComponent<TrainScript>();
        trainScript.trainData.SetTrainSpeed(20);

        yield return new WaitForSeconds(0.1f);

        Assert.AreNotEqual(wheelTransform.rotation.z, 0);
    }
}
