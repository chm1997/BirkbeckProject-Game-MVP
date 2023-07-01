using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class CheckAttackCooldownTests
{
    [TearDown]
    public void CheckAttackCooldownTests_TearDown()
    {
        foreach (GameObject o in Object.FindObjectsOfType<GameObject>())
        {
            GameObject.Destroy(o);
        }
    }

    [Test]
    public void CheckAttackCooldownTest()
    {
        GameObject gObj = new GameObject();
        gObj.AddComponent<Rigidbody2D>();
        gObj.GetComponent<Rigidbody2D>().velocity = Vector2.up;

        BehaviourNode parent = new BehaviourNode(new List<BehaviourNode> { new BehaviourNode(new List<BehaviourNode> { new CheckAttackCooldown(gObj.GetComponent<Rigidbody2D>(), 1f) }) });
        parent.SetData("hasAttacked", true);
        CheckAttackCooldown check = (CheckAttackCooldown)parent.children[0].children[0];

        Assert.AreEqual(check.waitCounter, 0);
        check.Evaluate();
        Assert.Greater(check.waitCounter, 0);

        for (int i = 0; i < 500; i++) 
        {
            check.Evaluate();

        }

        Assert.AreEqual(parent.GetData("hasAttacked"), false);
        Assert.AreEqual(gObj.GetComponent<Rigidbody2D>().velocity, Vector2.zero);
    }
}
