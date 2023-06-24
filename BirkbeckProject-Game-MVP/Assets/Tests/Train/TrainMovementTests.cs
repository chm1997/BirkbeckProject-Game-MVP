using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

public class TrainMovementTests
{
    GameObject playerPrefab = Resources.Load<GameObject>("Player");
    GameObject trainPrefab = Resources.Load<GameObject>("TrainMainObject");

    GameObject player;
    GameObject train;

    TrainMovementScript trainMovementScript;


    [UnitySetUp]
    public IEnumerator TrainMovementTest_Setup()
    {
        //Loop deletes all active game objects, required because child objects of TrainMainObject can persist
        foreach (GameObject o in Object.FindObjectsOfType<GameObject>())
        {
            GameObject.Destroy(o);
        }

        yield return null;

        player = GameObject.Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        train = GameObject.Instantiate(trainPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        train.GetComponent<Rigidbody2D>().gravityScale = 0;
        trainMovementScript = train.GetComponent<TrainMovementScript>();
        trainMovementScript.trainData.SetTrainSpeed(0);
    }

    [UnityTest]
    public IEnumerator TrainMovementTest_StationaryWhenSpeed0()
    {
        trainMovementScript.trainData.SetTrainSpeed(0);
        yield return new WaitForSeconds(0.5f);
        Assert.AreEqual(train.transform.position.x, 0);
    }

    [UnityTest]
    public IEnumerator TrainMovementTest_MoveRightWhenSpeedOver0()
    {
        trainMovementScript.trainData.SetTrainSpeed(100);
        yield return new WaitForSeconds(0.5f);
        Assert.Greater(train.transform.position.x, 0);
    }
}
