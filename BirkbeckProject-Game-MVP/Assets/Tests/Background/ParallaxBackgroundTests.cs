using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ParallaxBackgroundTests
{
    GameObject playerPrefab = Resources.Load<GameObject>("Player");
    GameObject cameraPrefab = Resources.Load<GameObject>("Main Camera");

    GameObject player;
    GameObject camera;

    Sprite testSprite = Resources.Load<Sprite>("TestSquare");

    GameObject testObject;

    [UnitySetUp]
    public IEnumerator ParallaxBackgroundTest_Setup()
    {
        player = GameObject.Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        yield return null;
        camera = GameObject.Instantiate(cameraPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        yield return null;

        testObject = new GameObject();

        testObject.transform.position = new Vector3 (0, 0, 0);
        testObject.AddComponent<SpriteRenderer>();
        testObject.GetComponent<SpriteRenderer>().sprite = testSprite;
        testObject.AddComponent<ParallaxBackground>();
        yield return null;
    }

    [TearDown]
    public void ParallaxBackgroundTest_TearDown()
    {
        Object.Destroy(testObject);
        Object.Destroy(camera);
        Object.Destroy(player);
    }


    [UnityTest]
    public IEnumerator ParallaxBackgroundTest_Stationary()
    {
        yield return null;

        Assert.AreEqual(0.0f, testObject.transform.position.x);
        Assert.AreEqual(0.0f, testObject.transform.position.y);

    }
    
    [UnityTest]
    public IEnumerator ParallaxBackgroundTest_HorizontalMovementLeftWithMultiplierOfOneZero()
    {
        testObject.GetComponent<ParallaxBackground>().parallaxEffectMultiplier = new Vector2(1,0);
        player.transform.position = new Vector2(-5, 0);

        yield return new WaitForSeconds(0.2f);

        Assert.That(-5.0f, Is.EqualTo(testObject.transform.position.x).Within(0.001));
        Assert.That(0.0f, Is.EqualTo(testObject.transform.position.y).Within(0.001));
    }

    [UnityTest]
    public IEnumerator ParallaxBackgroundTest_HorizontalMovementRightWithMultiplierOfOneZero()
    {
        testObject.GetComponent<ParallaxBackground>().parallaxEffectMultiplier = new Vector2(1, 0);
        player.transform.position = new Vector2(5, 0);

        yield return new WaitForSeconds(0.2f);

        Assert.That(5.0f, Is.EqualTo(testObject.transform.position.x).Within(0.001));
        Assert.That(0.0f, Is.EqualTo(testObject.transform.position.y).Within(0.001));
    }

    [UnityTest]
    public IEnumerator ParallaxBackgroundTest_VerticalMovementUpWithMultiplierOfZeroOne()
    {
        testObject.GetComponent<ParallaxBackground>().parallaxEffectMultiplier = new Vector2(0, 1);
        player.transform.position = new Vector2(0, 10);

        yield return new WaitForSeconds(0.2f);

        Assert.That(0.0f, Is.EqualTo(testObject.transform.position.x).Within(0.001));
        Assert.That(10.0f, Is.EqualTo(testObject.transform.position.y).Within(0.5));
    }

    [UnityTest]
    public IEnumerator ParallaxBackgroundTest_VerticalMovementDownWithMultiplierOfZeroOne()
    {
        testObject.GetComponent<ParallaxBackground>().parallaxEffectMultiplier = new Vector2(0, 1);
        player.transform.position = new Vector2(0, -10);

        yield return new WaitForSeconds(0.2f);

        Assert.That(0.0f, Is.EqualTo(testObject.transform.position.x).Within(0.001));
        Assert.That(-10.0f, Is.EqualTo(testObject.transform.position.y).Within(0.5));
    }

    [UnityTest]
    public IEnumerator ParallaxBackgroundTest_HorizontalMovementLeftWithMultiplierOfHalfZero()
    {
        testObject.GetComponent<ParallaxBackground>().parallaxEffectMultiplier = new Vector2(0.5f, 0);
        player.transform.position = new Vector2(-5, 0);

        yield return new WaitForSeconds(0.2f);

        Assert.That(-5.5f, Is.EqualTo(testObject.transform.position.x).Within(0.001));
        Assert.That(0.0f, Is.EqualTo(testObject.transform.position.y).Within(0.001));
    }

    [UnityTest]
    public IEnumerator ParallaxBackgroundTest_HorizontalMovementRightWithMultiplierOfHalfZero()
    {
        testObject.GetComponent<ParallaxBackground>().parallaxEffectMultiplier = new Vector2(0.5f, 0);
        player.transform.position = new Vector2(5, 0);

        yield return new WaitForSeconds(0.2f);

        Assert.That(5.5f, Is.EqualTo(testObject.transform.position.x).Within(0.001));
        Assert.That(0.0f, Is.EqualTo(testObject.transform.position.y).Within(0.001));
    }

    [UnityTest]
    public IEnumerator ParallaxBackgroundTest_VerticalMovementUpWithMultiplierOfZeroHalf()
    {
        testObject.GetComponent<ParallaxBackground>().parallaxEffectMultiplier = new Vector2(0, 0.5f);
        player.transform.position = new Vector2(0, 10);

        yield return new WaitForSeconds(0.2f);

        Assert.That(0.0f, Is.EqualTo(testObject.transform.position.x).Within(0.001));
        Assert.That(5.0f, Is.EqualTo(testObject.transform.position.y).Within(0.5));
    }

    [UnityTest]
    public IEnumerator ParallaxBackgroundTest_VerticalMovementDownWithMultiplierOfZeroHalf()
    {
        testObject.GetComponent<ParallaxBackground>().parallaxEffectMultiplier = new Vector2(0, 0.5f);
        player.transform.position = new Vector2(0, -10);

        yield return new WaitForSeconds(0.2f);

        Assert.That(0.0f, Is.EqualTo(testObject.transform.position.x).Within(0.001));
        Assert.That(-5.0f, Is.EqualTo(testObject.transform.position.y).Within(0.5));
    }

    [UnityTest]
    public IEnumerator ParallaxBackgroundTest_DiagonalMovementPositiveWithMultiplierOfOne()
    {
        testObject.GetComponent<ParallaxBackground>().parallaxEffectMultiplier = new Vector2(1, 1f);
        player.transform.position = new Vector2(10, 10);

        yield return new WaitForSeconds(0.2f);

        Assert.That(10.0f, Is.EqualTo(testObject.transform.position.x).Within(0.001));
        Assert.That(10.0f, Is.EqualTo(testObject.transform.position.y).Within(0.5));
    }

    [UnityTest]
    public IEnumerator ParallaxBackgroundTest_DiagonalMovementPositiveWithMultiplierOfHalf()
    {
        testObject.GetComponent<ParallaxBackground>().parallaxEffectMultiplier = new Vector2(0.5f, 0.5f);
        player.transform.position = new Vector2(10, 10);

        yield return new WaitForSeconds(0.2f);

        Assert.That(10.0f, Is.EqualTo(testObject.transform.position.x).Within(0.001));
        Assert.That(5.0f, Is.EqualTo(testObject.transform.position.y).Within(0.5));
    }

    [UnityTest]
    public IEnumerator ParallaxBackgroundTest_DiagonalMovementPositiveWithMultiplierOfQuarter()
    {
        testObject.GetComponent<ParallaxBackground>().parallaxEffectMultiplier = new Vector2(0.25f, 0.25f);
        player.transform.position = new Vector2(10, 10);

        yield return new WaitForSeconds(0.2f);

        Assert.That(10.5f, Is.EqualTo(testObject.transform.position.x).Within(0.001));
        Assert.That(2.5f, Is.EqualTo(testObject.transform.position.y).Within(0.5));
    }

    [UnityTest]
    public IEnumerator ParallaxBackgroundTest_DiagonalMovementNegativeWithMultiplierOfOne()
    {
        testObject.GetComponent<ParallaxBackground>().parallaxEffectMultiplier = new Vector2(1, 1f);
        player.transform.position = new Vector2(-10, -10);

        yield return new WaitForSeconds(0.2f);

        Assert.That(-10.0f, Is.EqualTo(testObject.transform.position.x).Within(0.001));
        Assert.That(-10.0f, Is.EqualTo(testObject.transform.position.y).Within(0.5));
    }

    [UnityTest]
    public IEnumerator ParallaxBackgroundTest_DiagonalMovementNegativeWithMultiplierOfHalf()
    {
        testObject.GetComponent<ParallaxBackground>().parallaxEffectMultiplier = new Vector2(0.5f, 0.5f);
        player.transform.position = new Vector2(-10, -10);

        yield return new WaitForSeconds(0.2f);

        Assert.That(-10.0f, Is.EqualTo(testObject.transform.position.x).Within(0.001));
        Assert.That(-5.0f, Is.EqualTo(testObject.transform.position.y).Within(0.5));
    }

    [UnityTest]
    public IEnumerator ParallaxBackgroundTest_DiagonalMovementNegativeWithMultiplierOfQuarter()
    {
        testObject.GetComponent<ParallaxBackground>().parallaxEffectMultiplier = new Vector2(0.25f, 0.25f);
        player.transform.position = new Vector2(-10, -10);

        yield return new WaitForSeconds(0.2f);

        Assert.That(-10.5f, Is.EqualTo(testObject.transform.position.x).Within(0.001));
        Assert.That(-2.5f, Is.EqualTo(testObject.transform.position.y).Within(0.5));
    }
}
