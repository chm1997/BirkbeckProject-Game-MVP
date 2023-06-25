using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

public class TrainScriptTests
{
    GameObject playerPrefab = Resources.Load<GameObject>("Player");
    GameObject trainPrefab = Resources.Load<GameObject>("TrainMainObject");

    GameObject player;
    GameObject train;

    TrainMovementScript trainMovementScript;
    Rigidbody2D trainRB2D;
    Rigidbody2D playerRB2D;

    [UnitySetUp]
    public IEnumerator TrainScriptTest_Setup()
    {
        //Loop deletes all active game objects, required because child objects of TrainMainObject can persist
        foreach (GameObject o in Object.FindObjectsOfType<GameObject>())
        {
            GameObject.Destroy(o);
        }

        yield return null;

        player = GameObject.Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        train = GameObject.Instantiate(trainPrefab, new Vector3(0, 0, 0), Quaternion.identity);

        playerRB2D = player.GetComponent<Rigidbody2D>();
        trainRB2D = train.GetComponent<Rigidbody2D>();

        playerRB2D.gravityScale = 0;
        trainRB2D.gravityScale = 0;

        trainMovementScript = train.GetComponent<TrainMovementScript>();
    }

    [UnityTest]
    public IEnumerator TrainScriptTest_TracksPlayerPositionOn()
    {
        train.transform.position = new Vector3(50, 0, 0);
        player.transform.position = new Vector3(50, 0, 0);

        yield return null;

        Assert.IsTrue(trainMovementScript.trainData.GetPlayerInTrain());
        Assert.IsTrue(trainMovementScript.trainData.GetPlayerAboveTrain());
    }

    [UnityTest]
    public IEnumerator TrainScriptTest_TracksPlayerPositionAbove()
    {
        train.transform.position = new Vector3(50, 0, 0);
        player.transform.position = new Vector3(50, 50, 0);

        yield return null;

        Assert.IsFalse(trainMovementScript.trainData.GetPlayerInTrain());
        Assert.IsTrue(trainMovementScript.trainData.GetPlayerAboveTrain());
    }

    [UnityTest]
    public IEnumerator TrainScriptTest_TracksPlayerPositionOutside()
    {
        train.transform.position = new Vector3(50, 0, 0);
        player.transform.position = new Vector3(0, 0, 0);

        yield return null;

        Assert.IsFalse(trainMovementScript.trainData.GetPlayerInTrain());
        Assert.IsFalse(trainMovementScript.trainData.GetPlayerAboveTrain());
    }

    [UnityTest]
    public IEnumerator TrainScriptTest_FuelStaysTheSameWhenSpeed0()
    {
        trainMovementScript.trainData.SetTrainSpeed(0);
        trainMovementScript.trainData.SetTrainFuel(100);

        yield return new WaitForSeconds(0.5f);

        Assert.AreEqual(trainMovementScript.trainData.GetTrainFuel(), 100);
    }


    [UnityTest]
    public IEnumerator TrainScriptTest_FuelDecreasesWhenSpeedAbove0()
    {
        trainMovementScript.trainData.SetTrainSpeed(100);
        trainMovementScript.trainData.SetTrainFuel(100);

        yield return new WaitForSeconds(0.5f);

        Assert.Less(trainMovementScript.trainData.GetTrainFuel(), 100);
    }

    [UnityTest]
    public IEnumerator TrainScriptTest_SpeedSetTo0WhenFuelRunsOut()
    {
        trainMovementScript.trainData.SetTrainSpeed(100);
        trainMovementScript.trainData.SetTrainFuel(1);

        yield return new WaitForSeconds(1f);

        Assert.LessOrEqual(trainMovementScript.trainData.GetTrainFuel(), 0);
        Assert.AreEqual(trainMovementScript.trainData.GetTrainSpeed(), 100);
    }
}
