using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TestTools;

[TestFixture]
public class CrosshairScriptTests : InputTestFixture
{
    GameObject playerPrefab = Resources.Load<GameObject>("Player");
    GameObject cameraPrefab = Resources.Load<GameObject>("Main Camera");
    GameObject crosshairPrefab = Resources.Load<GameObject>("Crosshair");

    GameObject player;
    GameObject camera;
    GameObject crosshair;
    
    Mouse mouse;
    Keyboard keyboard;

    public override void Setup()
    {
        base.Setup();
        mouse = InputSystem.AddDevice<Mouse>();
        keyboard = InputSystem.AddDevice<Keyboard>();
    }

    [SetUp]
    public void CrosshairScriptTest_Setup()
    {
        player = GameObject.Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        camera = GameObject.Instantiate(cameraPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        crosshair = GameObject.Instantiate(crosshairPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

    [TearDown]
    public void CrosshairScriptTest_TearDown()
    {
        Object.Destroy(crosshair);
        Object.Destroy(camera);
        Object.Destroy(player);
    }

    [UnityTest]
    public IEnumerator CrosshairScriptTest_FollowsMousePositionStationary()
    {

        Vector2 transformVector = new Vector2(10, 10);
        mouse.WarpCursorPosition(transformVector);

        yield return new WaitForSeconds(0.5f);

        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(transformVector);
        Assert.That(worldPosition.x, Is.EqualTo(crosshair.transform.position.x).Within(0.5));
        Assert.That(worldPosition.y, Is.EqualTo(crosshair.transform.position.y).Within(0.5));
    }

    [UnityTest]
    public IEnumerator CrosshairScriptTest_FollowsMousePositionUpRight()
    {

        Vector2 transformVector = new Vector2(10, 10);
        mouse.WarpCursorPosition(transformVector);

        yield return new WaitForSeconds(0.5f);

        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(transformVector);
        Assert.That(worldPosition.x, Is.EqualTo(crosshair.transform.position.x).Within(0.5));
        Assert.That(worldPosition.y, Is.EqualTo(crosshair.transform.position.y).Within(0.5));
    }

    [UnityTest]
    public IEnumerator CrosshairScriptTest_FollowsMousePositionDownLeft()
    {

        Vector2 transformVector = new Vector2(-10, -10);
        mouse.WarpCursorPosition(transformVector);

        yield return new WaitForSeconds(0.5f);

        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(transformVector);
        Assert.That(worldPosition.x, Is.EqualTo(crosshair.transform.position.x).Within(0.5));
        Assert.That(worldPosition.y, Is.EqualTo(crosshair.transform.position.y).Within(0.5));
    }

    [UnityTest]
    public IEnumerator CrosshairScriptTest_SendsSignal()
    {
        GameObject healthpack = GameObject.Instantiate(Resources.Load<GameObject>("HealthPack"), crosshair.transform.position, Quaternion.identity);
        Press(keyboard.eKey);

        yield return new WaitForSeconds(0.5f);

        Assert.AreEqual(healthpack.ToString(), "null");
    }
}
