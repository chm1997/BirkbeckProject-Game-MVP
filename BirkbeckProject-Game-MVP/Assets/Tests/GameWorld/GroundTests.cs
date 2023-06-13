using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GroundTests
{
    GameObject groundPrefab = Resources.Load<GameObject>("Ground");
    GameObject playerPrefab = Resources.Load<GameObject>("Player");

    [UnityTest]
    public IEnumerator GroundTest_Stationary()
    {
        GameObject playerStationary = GameObject.Instantiate(playerPrefab, new Vector3(0, 5, 0), Quaternion.identity);
        GameObject groundStationary = GameObject.Instantiate(groundPrefab, new Vector3(0, 0, 0), Quaternion.identity);

        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual(0.0f, groundStationary.transform.position.x);
        Assert.AreEqual(0.0f, groundStationary.transform.position.y);
        
        UnityEngine.Object.Destroy(playerStationary);
        UnityEngine.Object.Destroy(groundStationary);
    }

    [UnityTest]
    public IEnumerator GroundTest_HorizontalMovementLeft()
    {
        GameObject playerHorizontalMovementLeft = GameObject.Instantiate(playerPrefab, new Vector3(0, 5, 0), Quaternion.identity);
        GameObject groundHorizontalMovementLeft = GameObject.Instantiate(groundPrefab, new Vector3(0, 0, 0), Quaternion.identity);

        playerHorizontalMovementLeft.transform.position = new Vector2(-5, 0);

        yield return new WaitForSeconds(1.0f);

        Assert.AreEqual(-5.0f, groundHorizontalMovementLeft.transform.position.x);

        UnityEngine.Object.Destroy(playerHorizontalMovementLeft);
        UnityEngine.Object.Destroy(groundHorizontalMovementLeft);
    }

    [UnityTest]
    public IEnumerator GroundTest_HorizontalMovementRight()
    {
        GameObject playerHorizontalMovementRight = GameObject.Instantiate(playerPrefab, new Vector3(0, 5, 0), Quaternion.identity);
        GameObject groundHorizontalMovementRight = GameObject.Instantiate(groundPrefab, new Vector3(0, 0, 0), Quaternion.identity);

        playerHorizontalMovementRight.transform.position = new Vector2(5, 5);

        yield return new WaitForSeconds(1.0f);

        Assert.AreEqual(5.0f, groundHorizontalMovementRight.transform.position.x);

        UnityEngine.Object.Destroy(playerHorizontalMovementRight);
        UnityEngine.Object.Destroy(groundHorizontalMovementRight);
    }

    [UnityTest]
    public IEnumerator GroundTest_VerticalMovementUp()
    {
        GameObject playerVerticalMovementUp = GameObject.Instantiate(playerPrefab, new Vector3(0, 5, 0), Quaternion.identity);
        GameObject groundVerticalMovementUp = GameObject.Instantiate(groundPrefab, new Vector3(0, 0, 0), Quaternion.identity);

        playerVerticalMovementUp.transform.position = new Vector2(0, 5);

        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual(0.0f, groundVerticalMovementUp.transform.position.y);

        UnityEngine.Object.Destroy(playerVerticalMovementUp);
        UnityEngine.Object.Destroy(groundVerticalMovementUp);
    }

    [UnityTest]
    public IEnumerator GroundTest_VerticalMovementDown()
    {
        GameObject playerVerticalMovementDown = GameObject.Instantiate(playerPrefab, new Vector3(0, 5, 0), Quaternion.identity);
        GameObject groundVerticalMovementDown = GameObject.Instantiate(groundPrefab, new Vector3(0, 0, 0), Quaternion.identity);

        playerVerticalMovementDown.transform.position = new Vector2(0, -5);

        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual(0.0f, groundVerticalMovementDown.transform.position.y);

        UnityEngine.Object.Destroy(groundVerticalMovementDown);
        UnityEngine.Object.Destroy(groundVerticalMovementDown);
    }
}
