using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CameraTests
{
    GameObject playerPrefab = Resources.Load<GameObject>("Player");
    GameObject cameraPrefab = Resources.Load<GameObject>("Main Camera");

    GameObject player;
    GameObject camera;

    [SetUp]
    public void GroundTest_Setup()
    {
        player = GameObject.Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        camera = GameObject.Instantiate(cameraPrefab, new Vector3(0, 0, -10), Quaternion.identity);
    }

    [TearDown]
    public void GroundTest_TearDown()
    {
        UnityEngine.Object.Destroy(player);
        UnityEngine.Object.Destroy(camera);
    }


    [UnityTest]
    public IEnumerator GroundTest_Stationary()
    {
        yield return null;

        Assert.That(0.0f, Is.EqualTo(camera.transform.position.x).Within(0.001));
        Assert.That(5.0f, Is.EqualTo(camera.transform.position.y).Within(0.001));
    }

    [UnityTest]
    public IEnumerator GroundTest_HorizontalMovementLeft()
    {
        player.transform.position = new Vector2(-5, 0);

        yield return null;

        Assert.AreEqual(-5.0f, camera.transform.position.x);
    }

    [UnityTest]
    public IEnumerator GroundTest_HorizontalMovementRight()
    {
        player.transform.position = new Vector2(5, 0);

        yield return null;

        Assert.AreEqual(5.0f, camera.transform.position.x);
    }

    [UnityTest]
    public IEnumerator GroundTest_VerticalMovementUp()
    {
        player.transform.position = new Vector2(0, 5);

        yield return null;

        Assert.AreEqual(10.0f, camera.transform.position.y);
    }

    [UnityTest]
    public IEnumerator GroundTest_VerticalMovementDown()
    {
        player.transform.position = new Vector2(0, -5);

        yield return null;

        Assert.AreEqual(0.0f, camera.transform.position.y);
    }
}
