using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

public class CheckEnemyNumbersTests
{
    GameObject playerPrefab = Resources.Load<GameObject>("Player");
    GameObject enemyPrefab = Resources.Load<GameObject>("Enemy");

    GameObject player;

    [SetUp]
    public void CheckEnemyNumbersTests_Setup()
    {
        player = GameObject.Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

    [TearDown]
    public void CheckEnemyNumbersTests_TearDown()
    {
        foreach (GameObject o in Object.FindObjectsOfType<GameObject>())
        {
            GameObject.Destroy(o);
        }
    }

    [UnityTest]
    public IEnumerator CheckEnemyNumbersTest_ReturnFailureWhenBelowChangePoint()
    {
        GameObject enemy1 = GameObject.Instantiate(enemyPrefab, new Vector3(0, 0, 0), Quaternion.identity);

        enemy1.GetComponent<EnemyScript>().enemyData.SetBehaviourChangePoint(2);
        yield return null;

        CheckEnemyNumbers check = new CheckEnemyNumbers(enemy1.GetComponent<EnemyScript>().enemyData);
        NodeState nodeState = check.Evaluate();
        Assert.AreEqual(nodeState, NodeState.FAILURE);
    }

    [UnityTest]
    public IEnumerator CheckEnemyNumbersTest_ReturnRunningWhenAtChangePoint()
    {
        GameObject enemy1 = GameObject.Instantiate(enemyPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        GameObject enemy2 = GameObject.Instantiate(enemyPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        GameObject enemy3 = GameObject.Instantiate(enemyPrefab, new Vector3(0, 0, 0), Quaternion.identity);

        enemy1.GetComponent<EnemyScript>().enemyData.SetBehaviourChangePoint(3);
        yield return null;

        CheckEnemyNumbers check = new CheckEnemyNumbers(enemy1.GetComponent<EnemyScript>().enemyData);
        NodeState nodeState = check.Evaluate();
        Assert.AreEqual(nodeState, NodeState.RUNNING);
    }

    [UnityTest]
    public IEnumerator CheckEnemyNumbersTest_ReturnRunningWhenAboveChangePoint()
    {
        GameObject enemy1 = GameObject.Instantiate(enemyPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        GameObject enemy2 = GameObject.Instantiate(enemyPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        GameObject enemy3 = GameObject.Instantiate(enemyPrefab, new Vector3(0, 0, 0), Quaternion.identity);

        enemy1.GetComponent<EnemyScript>().enemyData.SetBehaviourChangePoint(2);
        yield return null;

        CheckEnemyNumbers check = new CheckEnemyNumbers(enemy1.GetComponent<EnemyScript>().enemyData);
        NodeState nodeState = check.Evaluate();
        Assert.AreEqual(nodeState, NodeState.RUNNING);
    }
}
