using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
public class EnemySpawnerScriptTests
{
    GameObject playerPrefab = Resources.Load<GameObject>("Player");
    GameObject enemySpawnerPrefab = Resources.Load<GameObject>("EnemySpawner");

    [TearDown]
    public void EnemySpawnerScriptTest_TearDown()
    {
        foreach (GameObject o in Object.FindObjectsOfType<GameObject>())
        {
            GameObject.Destroy(o);
        }
    }

    [UnityTest]
    public IEnumerator EnemySpawnerScriptTest_SpawnOnStartIfSetTo()
    {
        GameObject player = GameObject.Instantiate(playerPrefab, new Vector3(10, 0, 0), Quaternion.identity);
        GameObject enemySpawner = GameObject.Instantiate(enemySpawnerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        enemySpawner.GetComponent<EnemySpawnerScript>().enemyData.ResetEnemyCount();
        enemySpawner.GetComponent<EnemySpawnerScript>().spawnOnStartUp = true;

        yield return null;
        Assert.IsNotNull(GameObject.Find("Enemy(Clone)"));
    }

    [UnityTest]
    public IEnumerator EnemySpawnerScriptTest_DoNotSpawnOnStartIfNotSetTo()
    {
        GameObject player = GameObject.Instantiate(playerPrefab, new Vector3(10, 0, 0), Quaternion.identity);
        GameObject enemySpawner = GameObject.Instantiate(enemySpawnerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        enemySpawner.GetComponent<EnemySpawnerScript>().enemyData.ResetEnemyCount();
        enemySpawner.GetComponent<EnemySpawnerScript>().spawnOnStartUp = false;

        yield return null;
        Assert.IsNull(GameObject.Find("Enemy(Clone)"));
    }

    [UnityTest]
    public IEnumerator EnemySpawnerScriptTest_SpawnAfterXSeconds()
    {
        GameObject player = GameObject.Instantiate(playerPrefab, new Vector3(10, 0, 0), Quaternion.identity);
        GameObject enemySpawner = GameObject.Instantiate(enemySpawnerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        enemySpawner.GetComponent<EnemySpawnerScript>().enemyData.ResetEnemyCount();
        enemySpawner.GetComponent<EnemySpawnerScript>().spawnOnStartUp = false;
        enemySpawner.GetComponent<EnemySpawnerScript>().enemySpawnRate = 1;

        yield return new WaitForSeconds(1.5f);
        Assert.IsNotNull(GameObject.Find("Enemy(Clone)"));
    }

    [UnityTest]
    public IEnumerator EnemySpawnerScriptTest_SpawnAfterXSecondsTwice()
    {
        GameObject player = GameObject.Instantiate(playerPrefab, new Vector3(10, 0, 0), Quaternion.identity);
        GameObject enemySpawner = GameObject.Instantiate(enemySpawnerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        enemySpawner.GetComponent<EnemySpawnerScript>().enemyData.ResetEnemyCount();
        enemySpawner.GetComponent<EnemySpawnerScript>().spawnOnStartUp = false;
        enemySpawner.GetComponent<EnemySpawnerScript>().enemySpawnRate = 1;

        yield return new WaitForSeconds(2.5f);

        Assert.IsNotNull(GameObject.Find("Enemy(Clone)"));
        Assert.AreEqual(GameObject.FindObjectsOfType(typeof(EnemyScript)).Length, 2);
    }

    [UnityTest]
    public IEnumerator EnemySpawnerScriptTest_SpawnsSlowlyAboveBehaviourChangePoint()
    {
        GameObject player = GameObject.Instantiate(playerPrefab, new Vector3(10, 0, 0), Quaternion.identity);
        GameObject enemySpawner = GameObject.Instantiate(enemySpawnerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        enemySpawner.GetComponent<EnemySpawnerScript>().enemyData.ResetEnemyCount();
        enemySpawner.GetComponent<EnemySpawnerScript>().spawnOnStartUp = false;
        enemySpawner.GetComponent<EnemySpawnerScript>().enemySpawnRate = 1;
        enemySpawner.GetComponent<EnemySpawnerScript>().enemyData.SetBehaviourChangePoint(1);
        enemySpawner.GetComponent<EnemySpawnerScript>().enemyData.SetEnemyCountMax(10);

        yield return new WaitForSeconds(3.5f);

        Assert.AreEqual(GameObject.FindObjectsOfType(typeof(EnemyScript)).Length, 2);
    }

    [UnityTest]
    public IEnumerator EnemySpawnerScriptTest_StopsSpawningAtMax()
    {
        yield return new WaitForSeconds(1);

        GameObject player = GameObject.Instantiate(playerPrefab, new Vector3(10, 0, 0), Quaternion.identity);
        GameObject enemySpawner = GameObject.Instantiate(enemySpawnerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        enemySpawner.GetComponent<EnemySpawnerScript>().enemyData.ResetEnemyCount();
        enemySpawner.GetComponent<EnemySpawnerScript>().spawnOnStartUp = false;
        enemySpawner.GetComponent<EnemySpawnerScript>().enemySpawnRate = 1;
        enemySpawner.GetComponent<EnemySpawnerScript>().enemyData.SetBehaviourChangePoint(10);
        enemySpawner.GetComponent<EnemySpawnerScript>().enemyData.SetEnemyCountMax(3);
        enemySpawner.GetComponent <EnemySpawnerScript>().enemyData.ResetEnemyCount();

        yield return new WaitForSeconds(4.5f);

        Assert.AreEqual(GameObject.FindObjectsOfType(typeof(EnemyScript)).Length, 3);
    }
}
