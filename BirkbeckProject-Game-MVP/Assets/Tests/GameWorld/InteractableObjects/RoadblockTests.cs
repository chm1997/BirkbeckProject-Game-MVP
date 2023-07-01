using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

public class RoadblockTests
{
    GameObject roadblockPrefab = Resources.Load<GameObject>("Roadblock");
    GameObject roadblock;

    [UnitySetUp]
    public IEnumerator RoadblockTest_Setup()
    {
        foreach (GameObject o in Object.FindObjectsOfType<GameObject>())
        {
            GameObject.Destroy(o);
        }

        yield return null;

        roadblock = GameObject.Instantiate(roadblockPrefab, new Vector3(0, 0, 0), Quaternion.identity);
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
        roadblock.transform.position = new Vector2(30, 0);

        GameObject player = GameObject.Instantiate(Resources.Load<GameObject>("Player"), new Vector3(-50, 0, 0), Quaternion.identity);
        GameObject train = GameObject.Instantiate(Resources.Load<GameObject>("TrainMainObject"), new Vector3(0, 0, 0), Quaternion.identity);
        train.GetComponent<TrainMovementScript>().trainData.SetTrainSpeed(50);
        train.GetComponent<Rigidbody2D>().gravityScale = 0;

        yield return new WaitForSeconds(2f);
        Assert.AreEqual(train.transform.position.x, 25);
        Assert.AreEqual(train.transform.position.y, 0);
    }
}
