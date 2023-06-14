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

    [UnitySetUp]
    public IEnumerator CameraTest_Setup()
    {
        player = GameObject.Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        yield return null;
        camera = GameObject.Instantiate(cameraPrefab, new Vector3(0, 0, -10), Quaternion.identity);
        yield return null;
    }

    [TearDown]
    public void CameraTest_TearDown()
    {
        UnityEngine.Object.Destroy(player);
        UnityEngine.Object.Destroy(camera);
    }


    [UnityTest]
    public IEnumerator CameraTest_Stationary()
    {
        yield return null;

        Assert.That(0.0f, Is.EqualTo(camera.transform.position.x).Within(0.01));
        Assert.That(5.0f, Is.EqualTo(camera.transform.position.y).Within(0.01));
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
    public IEnumerator CameraTest_VerticalMovementUp()
    {
        player.transform.position = new Vector2(0, 5);

        yield return null;

        Assert.That(10.0f, Is.EqualTo(camera.transform.position.y).Within(0.01));
    }

    [UnityTest]
    public IEnumerator CameraTest_VerticalMovementDown()
    {
        player.transform.position = new Vector2(0, -5);

        yield return null;

        Assert.That(0.0f, Is.EqualTo(camera.transform.position.y).Within(0.01));
    }
}
