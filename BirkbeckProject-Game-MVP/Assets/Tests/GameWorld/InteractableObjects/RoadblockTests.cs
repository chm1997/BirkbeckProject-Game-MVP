using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

public class RoadblockTests
{
    GameObject roadblockPlaceholderObject;
    Roadblock roadblock;

    [SetUp]
    public void RoadblockTest_Setup()
    {
        roadblockPlaceholderObject = new GameObject();
        roadblockPlaceholderObject.AddComponent<Roadblock>();
        roadblock = roadblockPlaceholderObject.GetComponent<Roadblock>();
    }

    [TearDown]
    public void RoadblockTest_TearDown()
    {
        Object.Destroy(roadblockPlaceholderObject);
        Object.Destroy(roadblock);
    }

    [UnityTest]
    public IEnumerator RoadblockTest_DestroyedAfterInteraction()
    {
        roadblockPlaceholderObject.SendMessage("RecieveMessage", "");
        yield return null;
        Assert.AreEqual(roadblockPlaceholderObject.ToString(), "null");
    }

    [UnityTest]
    public IEnumerator RoadblockTest_TrainStopsNearby()
    {
        roadblockPlaceholderObject.transform.position = new Vector2(30, 0);

        GameObject player = GameObject.Instantiate(Resources.Load<GameObject>("Player"), new Vector3(-50, 0, 0), Quaternion.identity);
        GameObject train = GameObject.Instantiate(Resources.Load<GameObject>("TrainMainObject"), new Vector3(0, 0, 0), Quaternion.identity);
        train.GetComponent<TrainMovementScript>().trainData.SetTrainSpeed(50);
        train.GetComponent<Rigidbody2D>().gravityScale = 0;

        yield return new WaitForSeconds(2f);
        Assert.AreEqual(train.transform.position.x, 25);
        Assert.AreEqual(train.transform.position.y, 0);
    }
}
