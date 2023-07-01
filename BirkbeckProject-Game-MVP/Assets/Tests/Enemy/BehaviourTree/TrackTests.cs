using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackTests
{
    [TearDown]
    public void TrackTests_TearDown()
    {
        foreach (GameObject o in Object.FindObjectsOfType<GameObject>())
        {
            GameObject.Destroy(o);
        }
    }

    [Test]
    public void TrackTest()
    {
        GameObject gObj = new GameObject();
        gObj.transform.position = Vector3.zero;

        GameObject targetObject = new GameObject();
        targetObject.transform.position = new Vector3(10, 10, 10);

        Track track = new Track(targetObject.transform, gObj.transform, 5f);

        track.Evaluate();

        Assert.Greater(gObj.transform.position.x, 0);
        Assert.Greater(gObj.transform.position.y, 0);
    }
}
