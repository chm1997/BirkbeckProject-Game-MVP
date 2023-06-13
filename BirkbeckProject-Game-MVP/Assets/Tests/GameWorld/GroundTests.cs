using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GroundTests
{
    /*
    GameObject groundPrefab = Resources.Load<GameObject>("Ground");
    GameObject playerPrefab = Resources.Load<GameObject>("Player");

    [Test]
    public void GroundTest_Stationary()
    {
        GameObject ground = GameObject.Instantiate(groundPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        GameObject player = GameObject.Instantiate(playerPrefab, new Vector3(0, 5, 0), Quaternion.identity);

        Assert.AreEqual(0.0f, ground.transform.position.x);
        Assert.AreEqual(0.0f, ground.transform.position.y);
    }
    */


    [UnityTest]
    public IEnumerator GroundTest_HorizontalMovementLeft()
    {
        GameObject playerPrefab = Resources.Load<GameObject>("Player");
        Debug.Log(playerPrefab);
        GameObject player = GameObject.Instantiate(playerPrefab, new Vector3(0, 5, 0), Quaternion.identity);
        Debug.Log(player);

        GameObject groundPrefab = Resources.Load<GameObject>("Ground");
        Debug.Log(groundPrefab);
        GameObject ground = GameObject.Instantiate(groundPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        Debug.Log(ground);

        player.transform.position = new Vector2(-5, 0);

        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual(-5.0f, ground.transform.position.x);
    }
    /*
    [Test]
    public void GroundTest_HorizontalMovementRight()
    {
        GameObject ground = GameObject.Instantiate(groundPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        GameObject player = GameObject.Instantiate(playerPrefab, new Vector3(0, 5, 0), Quaternion.identity);

        player.transform.position = new Vector2(5, 0);

        Assert.AreEqual(5.0f, ground.transform.position.x);
    }

    [Test]
    public void GroundTest_VerticalMovementUp()
    {
        GameObject ground = GameObject.Instantiate(groundPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        GameObject player = GameObject.Instantiate(playerPrefab, new Vector3(0, 5, 0), Quaternion.identity);

        player.transform.position = new Vector2(0, 5);

        Assert.AreEqual(0.0f, ground.transform.position.y);
    }

    [Test]
    public void GroundTest_VerticalMovementDown()
    {
        GameObject ground = GameObject.Instantiate(groundPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        GameObject player = GameObject.Instantiate(playerPrefab, new Vector3(0, 5, 0), Quaternion.identity);

        player.transform.position = new Vector2(0, -5);

        Assert.AreEqual(0.0f, ground.transform.position.y);
    }
    */
}
