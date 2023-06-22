using System.Collections;
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
        Object.Destroy(player);
        Object.Destroy(camera);
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
}
