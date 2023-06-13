using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GroundTests
{
    GameObject groundPrefab = Resources.Load<GameObject>("Ground");
    GameObject playerPrefab = Resources.Load<GameObject>("Player");

    GameObject player;
    GameObject ground;

    [SetUp]
    public void GroundTest_Setup()
    {
        Debug.Log("set up");
        player = GameObject.Instantiate(playerPrefab, new Vector3(0, 5, 0), Quaternion.identity);
        ground = GameObject.Instantiate(groundPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

    [TearDown]
    public void GroundTest_TearDown()
    {
        Debug.Log("tear down");
        UnityEngine.Object.Destroy(player);
        UnityEngine.Object.Destroy(ground);
    }


    [UnityTest]
    public IEnumerator GroundTest_Stationary()
    {
        yield return new WaitForSeconds(0.5f);

        Assert.AreEqual(0.0f, ground.transform.position.x);
        Assert.AreEqual(0.0f, ground.transform.position.y);
    }
    
    [UnityTest]
    public IEnumerator GroundTest_HorizontalMovementLeft()
    {
        player.transform.position = new Vector2(-5, 0);

        yield return new WaitForSeconds(1.0f);

        Assert.AreEqual(-5.0f, ground.transform.position.x);
    }
    
    [UnityTest]
    public IEnumerator GroundTest_HorizontalMovementRight()
    {
        player.transform.position = new Vector2(5, 5);

        yield return new WaitForSeconds(1.0f);

        Assert.AreEqual(5.0f, ground.transform.position.x);
    }

    [UnityTest]
    public IEnumerator GroundTest_VerticalMovementUp()
    {
        player.transform.position = new Vector2(0, 5);

        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual(0.0f, ground.transform.position.y);
    }

    [UnityTest]
    public IEnumerator GroundTest_VerticalMovementDown()
    {
        player.transform.position = new Vector2(0, -5);

        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual(0.0f, ground.transform.position.y);
    }
}
