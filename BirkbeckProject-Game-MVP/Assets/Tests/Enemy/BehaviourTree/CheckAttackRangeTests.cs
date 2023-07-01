using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class CheckAttackRangeTests
{
    [TearDown]
    public void CheckAttackRangeTests_TearDown()
    {
        foreach (GameObject o in Object.FindObjectsOfType<GameObject>())
        {
            GameObject.Destroy(o);
        }
    }

    [Test]
    public void CheckAttackRangeTest_Running()
    {
        GameObject gObj = new GameObject();
        gObj.transform.position = Vector3.zero;
        gObj.AddComponent<BoxCollider2D>();

        GameObject targetObj = new GameObject();
        targetObj.transform.position = new Vector3(0.5f, 0.5f, 0.5f);
        targetObj.AddComponent<BoxCollider2D>();
        targetObj.layer = 8;

        BehaviourNode parent = new BehaviourNode(new List<BehaviourNode> { new BehaviourNode(new List<BehaviourNode> { new CheckAttackRange(gObj.GetComponent<Transform>(), 1f, 256) }) });

        parent.SetData("hasAttacked", false);
        CheckAttackRange check = (CheckAttackRange)parent.children[0].children[0];

        NodeState state = check.Evaluate();
        Assert.AreEqual(state, NodeState.RUNNING);
    }

    [Test]
    public void CheckAttackRangeTest_Failure()
    {
        GameObject gObj = new GameObject();
        gObj.transform.position = Vector3.zero;
        gObj.AddComponent<BoxCollider2D>();

        GameObject targetObj = new GameObject();
        targetObj.transform.position = new Vector3(10, 10, 10);
        targetObj.AddComponent<BoxCollider2D>();
        targetObj.layer = 8;

        BehaviourNode parent = new BehaviourNode(new List<BehaviourNode> { new BehaviourNode(new List<BehaviourNode> { new CheckAttackRange(gObj.GetComponent<Transform>(), 5f, 256) }) });

        parent.SetData("hasAttacked", false);
        CheckAttackRange check = (CheckAttackRange)parent.children[0].children[0];

        NodeState state = check.Evaluate();
        Assert.AreEqual(state, NodeState.FAILURE);
    }
}
