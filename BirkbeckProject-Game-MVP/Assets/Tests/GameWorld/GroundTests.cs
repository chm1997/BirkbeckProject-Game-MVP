using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GroundTests
{
    GameObject playerPrefab = Resources.Load<GameObject>("Player");
    GameObject groundPrefab = Resources.Load<GameObject>("Ground");

    GameObject player;
    GameObject ground;

    [SetUp]
    public void GroundTest_Setup()
    {
        player = GameObject.Instantiate(playerPrefab, new Vector3(0, 5, 0), Quaternion.identity);
        ground = GameObject.Instantiate(groundPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

    [TearDown]
    public void GroundTest_TearDown()
    {
        Object.Destroy(player);
        Object.Destroy(ground);
    }


    [UnityTest]
    public IEnumerator GroundTest_Stationary()
    {
        yield return new WaitForSeconds(0.2f);

        Assert.That(0.0f, Is.EqualTo(ground.transform.position.x).Within(0.01));
        Assert.That(0.0f, Is.EqualTo(ground.transform.position.y).Within(0.01));
    }
    
    [UnityTest]
    public IEnumerator GroundTest_HorizontalMovementLeft()
    {
        player.transform.position = new Vector2(-5, 0);

        yield return new WaitForSeconds(0.2f);

        Assert.That(-5.0f, Is.EqualTo(ground.transform.position.x).Within(0.01));
    }
    
    [UnityTest]
    public IEnumerator GroundTest_HorizontalMovementRight()
    {
        player.transform.position = new Vector2(5, 5);

        yield return new WaitForSeconds(0.2f);

        Assert.That(5.0f, Is.EqualTo(ground.transform.position.x).Within(0.01));
    }

    [UnityTest]
    public IEnumerator GroundTest_VerticalMovementUp()
    {
        player.transform.position = new Vector2(0, 5);

        yield return new WaitForSeconds(0.2f);

        Assert.That(0.0f, Is.EqualTo(ground.transform.position.y).Within(0.01));
    }

    [UnityTest]
    public IEnumerator GroundTest_VerticalMovementDown()
    {
        player.transform.position = new Vector2(0, -5);

        yield return new WaitForSeconds(0.2f);

        Assert.That(0.0f, Is.EqualTo(ground.transform.position.y).Within(0.01));
    }
}
