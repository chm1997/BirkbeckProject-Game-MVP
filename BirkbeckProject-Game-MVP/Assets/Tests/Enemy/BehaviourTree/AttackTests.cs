using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

public class AttackTests
{
    [TearDown]
    public void AttackCooldownTests_TearDown()
    {
        foreach (GameObject o in Object.FindObjectsOfType<GameObject>())
        {
            GameObject.Destroy(o);
        }
    }

    [UnityTest]
    public IEnumerator AttackTest()
    {
        GameObject gObj = new GameObject();
        gObj.transform.position = Vector3.zero;
        gObj.AddComponent<Rigidbody2D>();
        gObj.GetComponent<Rigidbody2D>().velocity = Vector3.zero;

        GameObject targetObj = new GameObject();
        targetObj.transform.position = new Vector3(5, 5, 5);

        BehaviourNode parent = new BehaviourNode(new List<BehaviourNode> { new BehaviourNode(new List<BehaviourNode> { new Attack(gObj.transform, gObj.GetComponent<Rigidbody2D>())}) });

        parent.SetData("hasAttacked", false);
        parent.SetData("target", targetObj.transform);
        Attack attack = (Attack)parent.children[0].children[0];

        attack.Evaluate();

        yield return new WaitForSeconds(0.2f);

        Assert.Greater(gObj.transform.position.x, 0);
        Assert.Greater(gObj.transform.position.y, 0);
    }
}
