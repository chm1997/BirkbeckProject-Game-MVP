using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
public class EnemySpawnerScriptTests
{
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
        GameObject enemySpawner = GameObject.Instantiate(enemySpawnerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        enemySpawner.GetComponent<EnemySpawnerScript>().spawnOnStartUp = true;

        yield return null;
        Assert.IsNotNull(GameObject.Find("EnemySquare(Clone)"));
    }

    [UnityTest]
    public IEnumerator EnemySpawnerScriptTest_DoNotSpawnOnStartIfNotSetTo()
    {
        GameObject enemySpawner = GameObject.Instantiate(enemySpawnerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        enemySpawner.GetComponent<EnemySpawnerScript>().spawnOnStartUp = false;

        yield return null;
        Assert.IsNull(GameObject.Find("EnemySquare(Clone)"));
    }

    [UnityTest]
    public IEnumerator EnemySpawnerScriptTest_SpawnAfterXSeconds()
    {
        GameObject enemySpawner = GameObject.Instantiate(enemySpawnerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        enemySpawner.GetComponent<EnemySpawnerScript>().spawnOnStartUp = false;
        enemySpawner.GetComponent<EnemySpawnerScript>().enemySpawnRate = 1;

        yield return new WaitForSeconds(1.5f);
        Assert.IsNotNull(GameObject.Find("EnemySquare(Clone)"));
    }

    [UnityTest]
    public IEnumerator EnemySpawnerScriptTest_SpawnAfterXSecondsTwice()
    {
        GameObject enemySpawner = GameObject.Instantiate(enemySpawnerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        enemySpawner.GetComponent<EnemySpawnerScript>().spawnOnStartUp = false;
        enemySpawner.GetComponent<EnemySpawnerScript>().enemySpawnRate = 1;

        yield return new WaitForSeconds(2.5f);

        Assert.IsNotNull(GameObject.Find("EnemySquare(Clone)"));
        Assert.AreEqual(GameObject.FindObjectsOfType(typeof(Enemy)).Length, 2);
    }
}
