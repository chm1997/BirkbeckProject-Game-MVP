using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;


public class SteeringWheelTests
{
    GameObject playerPrefab = Resources.Load<GameObject>("Player");
    GameObject trainPrefab = Resources.Load<GameObject>("TrainMainObject");

    GameObject player;
    GameObject train;
    GameObject trainSteeringWheel;
    InteractableTrainSteeringWheel tranSteeringWheelScript;

    [UnitySetUp]
    public IEnumerator SteeringWheelTest_Setup()
    {
        //Loop deletes all active game objects, required because child objects of TrainMainObject can persist
        foreach (GameObject o in Object.FindObjectsOfType<GameObject>())
        {
            GameObject.Destroy(o);
        }

        yield return null;

        player = GameObject.Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        train = GameObject.Instantiate(trainPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        trainSteeringWheel = train.transform.Find("TrainMainSpriteObject").transform.Find("TrainInteriorSpriteObject").transform.Find("SteeringWheel").gameObject;
        tranSteeringWheelScript = trainSteeringWheel.GetComponent<InteractableTrainSteeringWheel>();
    }

    [UnityTest]
    public IEnumerator SteeringWheelTest_TrainSpeedIncreaseFromOff()
    {
        tranSteeringWheelScript.trainData.SetTrainSpeed(0);
        trainSteeringWheel.SendMessage("RecieveMessage", "");
        yield return null;
        Assert.Greater(tranSteeringWheelScript.trainData.GetTrainSpeed(), 10);
    }

    [UnityTest]
    public IEnumerator SteeringWheelTest_TrainSpeedDecreaseFromOn()
    {
        tranSteeringWheelScript.trainData.SetTrainSpeed(10);
        trainSteeringWheel.SendMessage("RecieveMessage", "");
        yield return null;
        Assert.Less(tranSteeringWheelScript.trainData.GetTrainSpeed(), 10);
    }
}
