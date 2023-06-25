using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

[TestFixture]
public class PlayerMovementTestsWithTrain
{
    GameObject playerPrefab = Resources.Load<GameObject>("Player");
    GameObject trainPrefab = Resources.Load<GameObject>("TrainMainObject");
    GameObject player;
    Rigidbody2D playerRB2D;
    GameObject train;

    [UnitySetUp]
    public IEnumerator PlayerMovementTest_Setup()
    {
        //Loop deletes all active game objects, required because child objects of TrainMainObject can persist
        foreach (GameObject o in Object.FindObjectsOfType<GameObject>())
        {
            GameObject.Destroy(o);
        }

        yield return null;

        train = GameObject.Instantiate(trainPrefab, new Vector3(100, 100, 0), Quaternion.identity);
        train.GetComponent<Rigidbody2D>().gravityScale = 0;

        player = GameObject.Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        playerRB2D = player.GetComponent<Rigidbody2D>();
        playerRB2D.gravityScale = 0;
    }

    [UnityTest]
    public IEnumerator PlayerMovementTest_PlayerTracksTrainMovementWhenOn()
    {
        player.transform.position = new Vector3(100, 100, 0);
        train.GetComponent<TrainScript>().trainData.SetTrainSpeed(50);

        yield return new WaitForSeconds(1f);

        Assert.Greater(playerRB2D.velocity.x, 5);
    }

    [UnityTest]
    public IEnumerator PlayerMovementTest_PlayerTracksTrainMovementWhenAbove()
    {
        player.transform.position = new Vector3(100, 130, 0);
        train.GetComponent<TrainScript>().trainData.SetTrainSpeed(50);

        yield return new WaitForSeconds(1f);

        Assert.Greater(playerRB2D.velocity.x, 5);
    }

    [UnityTest]
    public IEnumerator PlayerMovementTest_PlayerDoesNotTrackTrainMovementWhenNotOn()
    {
        player.transform.position = new Vector3(0, 0, 0);
        train.GetComponent<TrainScript>().trainData.SetTrainSpeed(50);

        yield return new WaitForSeconds(1f);
        Assert.AreEqual(playerRB2D.velocity, Vector2.zero);
    }
}