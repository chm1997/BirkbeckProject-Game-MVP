using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

public class EnemyScriptTests
{
    GameObject playerPrefab = Resources.Load<GameObject>("Player");
    GameObject enemyPrefab = Resources.Load<GameObject>("Enemy");

    GameObject player;
    GameObject enemy;

    [SetUp]
    public void EnemyScriptTest_Setup()
    {
        player = GameObject.Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        enemy = GameObject.Instantiate(enemyPrefab, new Vector3(10, 0, 0), Quaternion.identity);
        enemy.GetComponent<EnemyScript>().enemyData.ResetEnemyCount();
    }

    [TearDown]
    public void EnemyScriptTest_TearDown()
    {
        GameObject.Destroy(player);
        GameObject.Destroy(enemy);
    }

    [UnityTest]
    public IEnumerator EnemyScriptTest_KnockbackOnPlayerCollision()
    {
        enemy.transform.position = Vector3.zero;
        yield return new WaitForSeconds(0.1f);
        Assert.AreNotEqual(enemy.GetComponent<Rigidbody2D>().velocity, Vector2.zero);
    }

    [UnityTest]
    public IEnumerator EnemyScriptTest_PlayerLosesHealthOnPlayerCollision()
    {
        player.GetComponent<PlayerScript>().playerHealth.SetPlayerHealth(2);
        enemy.transform.position = Vector3.zero;
        yield return new WaitForSeconds(0.1f);
        Assert.AreEqual(player.GetComponent<PlayerScript>().playerHealth.GetPlayerHealth(), 1);
    }
}