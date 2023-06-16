using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TestTools;

[TestFixture]
public class CrosshairScriptTests : InputTestFixture
{
    GameObject crosshairPrefab = Resources.Load<GameObject>("Crosshair");
    GameObject crosshair;

    Keyboard keyboard;
    Mouse mouse;

    public override void Setup()
    {
        base.Setup();
        keyboard = InputSystem.AddDevice<Keyboard>();
        mouse = InputSystem.AddDevice<Mouse>();
    }

    [SetUp]
    public void CrosshairScriptTest_Setup()
    {
        crosshair = GameObject.Instantiate(crosshairPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

    [TearDown]
    public void CrosshairScriptTest_TearDown()
    {
        Object.Destroy(crosshair);
    }

    [UnityTest]
    public IEnumerator CrosshairScriptTest_AtMouse()
    {
        mouse.WarpCursorPosition(new Vector2(0, 0));

        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual(crosshair.transform.position.x, 0.0f);
        Assert.AreEqual(crosshair.transform.position.y, 0.0f);
    }

    [UnityTest]
    public IEnumerator CrosshairScriptTest_FollowsMouseUpRight()
    {
        mouse.WarpCursorPosition(new Vector2(10, 10));

        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual(crosshair.transform.position.x, 10.0f);
        Assert.AreEqual(crosshair.transform.position.y, 10.0f);
    }

    [UnityTest]
    public IEnumerator CrosshairScriptTest_FollowsMouseDownLeft()
    {
        mouse.WarpCursorPosition(new Vector2(-10, -10));

        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual(crosshair.transform.position.x, -10.0f);
        Assert.AreEqual(crosshair.transform.position.y, -10.0f);
    }
}
