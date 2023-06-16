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

    public override void Setup()
    {
        base.Setup();
        mouse = InputSystem.AddDevice<Mouse>();
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
    public IEnumerator CrosshairScriptTest_FollowsMousePosition()
    {

        Vector2 transformVector = new Vector2(0, 0);
        mouse.WarpCursorPosition(transformVector);

        yield return new WaitForSeconds(0.5f);

        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(transformVector);

        Assert.AreEqual(worldPosition.x, crosshair.transform.position.x);
        Assert.AreEqual(worldPosition.y, crosshair.transform.position.y);
    }
}
