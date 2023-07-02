using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CameraTests
{
    GameObject playerPrefab = Resources.Load<GameObject>("Player");
    GameObject trainPrefab = Resources.Load<GameObject>("TrainMainObject");
    GameObject cameraPrefab = Resources.Load<GameObject>("Main Camera");

    GameObject player;
    GameObject train;
    GameObject camera;

    [UnitySetUp]
    public IEnumerator CameraTest_Setup()
    {
        player = GameObject.Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        yield return null;
        train = GameObject.Instantiate(trainPrefab, new Vector3(50, 0, 0), Quaternion.identity);
        yield return null;
        camera = GameObject.Instantiate(cameraPrefab, new Vector3(0, 0, -10), Quaternion.identity);
        yield return null;
    }

    [TearDown]
    public void CameraTest_TearDown()
    {
        //Loop deletes all active game objects, required because child objects of TrainMainObject can persist
        foreach (GameObject o in Object.FindObjectsOfType<GameObject>())
        {
            GameObject.Destroy(o);
        }
    }


    [UnityTest]
    public IEnumerator CameraTest_Stationary()
    {
        yield return null;

        Assert.That(0.0f, Is.EqualTo(camera.transform.position.x).Within(0.1));
        Assert.That(4.5f, Is.EqualTo(camera.transform.position.y).Within(0.1));
    }

    [UnityTest]
    public IEnumerator CameraTest_HorizontalMovementLeft()
    {
        player.transform.position = new Vector2(-5, 0);

        yield return null;

        Assert.That(-5.0f, Is.EqualTo(camera.transform.position.x).Within(0.01));
    }

    [UnityTest]
    public IEnumerator CameraTest_HorizontalMovementRight()
    {
        player.transform.position = new Vector2(5, 0);

        yield return null;

        Assert.That(5.0f, Is.EqualTo(camera.transform.position.x).Within(0.01));
    }

    [UnityTest]
    public IEnumerator CameraTest_NoVerticalMovementUp()
    {
        player.transform.position = new Vector2(0, 5);

        yield return null;

        Assert.That(4.5f, Is.EqualTo(camera.transform.position.y).Within(0.01));
    }

    [UnityTest]
    public IEnumerator CameraTest_NoVerticalMovementDown()
    {
        player.transform.position = new Vector2(0, -5);

        yield return null;

        Assert.That(4.5f, Is.EqualTo(camera.transform.position.y).Within(0.01));
    }

    [UnityTest]
    public IEnumerator CameraTest_ZoomOutWhenAbovePlayerAndTrainSpeedOn()
    {
        player.transform.position = new Vector2(50, -1);
        train.GetComponent<TrainMovementScript>().trainData.SetTrainSpeed(30);

        yield return new WaitForSeconds(0.2f);
        Assert.Greater(camera.transform.position.y, 4.5f);
        Assert.Greater(camera.GetComponent<Camera>().orthographicSize, 10f);
    }
}
