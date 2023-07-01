using NUnit.Framework;
using UnityEngine;

public class CircleTargetTests
{
    [TearDown]
    public void CircleTargetTests_TearDown()
    {
        foreach (GameObject o in Object.FindObjectsOfType<GameObject>())
        {
            GameObject.Destroy(o);
        }
    }

    [Test]
    public void CircleTargetTest()
    {
        GameObject targetObject = new GameObject();

        GameObject trackingObject = new GameObject();
        trackingObject.AddComponent<Rigidbody2D>();

        CircleTarget circle = new CircleTarget(
            targetObject.GetComponent<Transform>(),
            trackingObject.GetComponent<Transform>(),
            trackingObject.GetComponent<Rigidbody2D>(),
            10f,
            1
        );

        for ( int i = 0; i < 5; i++ )
        {
            circle.Evaluate();
            Assert.GreaterOrEqual(circle.pointAboveTarget.x, -1);
            Assert.LessOrEqual(circle.pointAboveTarget.x, 1);
            Assert.GreaterOrEqual(circle.pointAboveTarget.y, 0);
            Assert.LessOrEqual(circle.pointAboveTarget.y, 1);
            Assert.AreNotEqual(circle.pointAboveTarget, Vector2.zero);
            Assert.AreNotEqual(circle.currentPos, circle.pointAboveTarget);
        }
    }
}
