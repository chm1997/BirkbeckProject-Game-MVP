using System.Collections;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    /// <summary>
    /// This class handles the creation of enemy objects based on their prefab and a variable timer
    /// Required Fields:
    /// GameObject enemyPrefab: a prefab of enemy that object wants to spawn
    /// int enemySpawnRate: the time (in seconds) between spawning of set prefab
    /// bool spawnOnStartUp: an option for spawning set prefab once on object start
    /// </summary>

    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    internal int enemySpawnRate = 10;

    [SerializeField]
    internal bool spawnOnStartUp = true;

    void Start()
    {
        if (spawnOnStartUp) GameObject.Instantiate(enemyPrefab, transform.localPosition, Quaternion.identity);
        StartCoroutine(SpawnAnEnemyEvertXSeconds());
    }

    private IEnumerator SpawnAnEnemyEvertXSeconds()
    {
        yield return new WaitForSeconds(enemySpawnRate);
        GameObject.Instantiate(enemyPrefab, transform.localPosition, Quaternion.identity);
        StartCoroutine(SpawnAnEnemyEvertXSeconds());
    }
}
