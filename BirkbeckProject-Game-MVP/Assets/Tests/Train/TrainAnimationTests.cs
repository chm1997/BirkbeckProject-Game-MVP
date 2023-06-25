using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

public class TrainAnimationTests
{
    GameObject trainPrefab = Resources.Load<GameObject>("TrainMainObject");
    GameObject playerPrefab = Resources.Load<GameObject>("Player");

    [SetUp]
    public void TrainAnimationTest_Setup()
    {
        //Loop deletes all active game objects, required because child objects of TrainMainObject can persist
        foreach (GameObject o in Object.FindObjectsOfType<GameObject>())
        {
            GameObject.Destroy(o);
        }
    }

    [UnityTest]
    public IEnumerator TrainAnimationTest_FrontSpriteEnabledWhenPlayerObjectOutside()
    {
        GameObject player = GameObject.Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        GameObject train = GameObject.Instantiate(trainPrefab, new Vector3(0, 0, 0), Quaternion.identity);

        train.transform.position = new Vector3(50, 0, 0);
        player.transform.position = new Vector3(0, 0, 0);

        yield return null;

        Assert.IsTrue(train.transform.Find("TrainMainSpriteObject").transform.Find("TrainFrontSprite").GetComponent<SpriteRenderer>().enabled);
    }

    [UnityTest]
    public IEnumerator TrainAnimationTest_FrontSpriteDisabledWhenPlayerObjectInside()
    {
        GameObject player = GameObject.Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        GameObject train = GameObject.Instantiate(trainPrefab, new Vector3(0, 0, 0), Quaternion.identity);

        train.transform.position = new Vector3(50, 0, 0);
        player.transform.position = new Vector3(50,0, 0);

        yield return null;

        Assert.IsFalse(train.transform.Find("TrainMainSpriteObject").transform.Find("TrainFrontSprite").GetComponent<SpriteRenderer>().enabled);
    }
}