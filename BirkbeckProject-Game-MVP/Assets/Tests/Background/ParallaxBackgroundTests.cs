using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ParallaxBackgroundTests
{
    GameObject playerPrefab = Resources.Load<GameObject>("Player");
    GameObject cameraPrefab = Resources.Load<GameObject>("Main Camera");
    GameObject cactiPrefab = Resources.Load<GameObject>("Cacti");
    //var test = new GameObject().AddComponent<MyScript>();

    GameObject player;
    GameObject camera;
    GameObject cacti;

    [SetUp]
    public void ParallaxBackgroundTest_Setup()
    {
        player = GameObject.Instantiate(playerPrefab, new Vector3(0, 5, 0), Quaternion.identity);
        camera = GameObject.Instantiate(cameraPrefab, new Vector3(0, 5, 0), Quaternion.identity);
        cacti = GameObject.Instantiate(cactiPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

    [TearDown]
    public void ParallaxBackgroundTest_TearDown()
    {
        UnityEngine.Object.Destroy(player);
        UnityEngine.Object.Destroy(camera);
        UnityEngine.Object.Destroy(cacti);
    }


    [UnityTest]
    public IEnumerator ParallaxBackgroundTest_Stationary()
    {
        yield return new WaitForSeconds(0.5f);

        Assert.AreEqual(0.0f, cacti.transform.position.x);
        Assert.AreEqual(0.0f, cacti.transform.position.y);
    }

    [UnityTest]
    public IEnumerator ParallaxBackgroundTest_HorizontalMovementLeft()
    {
        camera.transform.position = new Vector2(-5, 0);

        yield return new WaitForSeconds(1.0f);

        Assert.AreEqual(-5.0f, cacti.transform.position.x);
    }

    [UnityTest]
    public IEnumerator ParallaxBackgroundTest_HorizontalMovementRight()
    {
        camera.transform.position = new Vector2(5, 5);

        yield return new WaitForSeconds(1.0f);

        Assert.AreEqual(5.0f, cacti.transform.position.x);
    }

    [UnityTest]
    public IEnumerator ParallaxBackgroundTest_VerticalMovementUp()
    {
        camera.transform.position = new Vector2(0, 5);

        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual(0.0f, cacti.transform.position.y);
    }

    [UnityTest]
    public IEnumerator ParallaxBackgroundTest_VerticalMovementDown()
    {
        camera.transform.position = new Vector2(0, -5);

        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual(0.0f, cacti.transform.position.y);
    }
}
