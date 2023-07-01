using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

public class RoadblockTests
{
    GameObject playerPrefab = Resources.Load<GameObject>("Player");
    GameObject trainPrefab = Resources.Load<GameObject>("TrainMainObject");
    GameObject roadblockPrefab = Resources.Load<GameObject>("Roadblock");

    GameObject player;
    GameObject train;
    GameObject roadblock;

    [UnitySetUp]
    public IEnumerator RoadblockTest_Setup()
    {
        foreach (GameObject o in Object.FindObjectsOfType<GameObject>())
        {
            GameObject.Destroy(o);
        }

        yield return null;

        player = GameObject.Instantiate(playerPrefab, new Vector3(-50, 0, 0), Quaternion.identity);
        train = GameObject.Instantiate(trainPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        roadblock = GameObject.Instantiate(roadblockPrefab, new Vector3(30, 0, 0), Quaternion.identity);
    }

    [UnityTest]
    public IEnumerator RoadblockTest_DestroyedAfterInteraction()
    {
        roadblock.SendMessage("RecieveMessage", "");
        yield return null;
        Assert.AreEqual(roadblock.ToString(), "null");
    }

    [UnityTest]
    public IEnumerator RoadblockTest_TrainStopsNearby()
    {
        train.GetComponent<TrainMovementScript>().trainData.SetTrainSpeed(50);
        train.GetComponent<Rigidbody2D>().gravityScale = 0;

        yield return new WaitForSeconds(2f);
        Assert.LessOrEqual(train.transform.position.x, 25);
    }
}
