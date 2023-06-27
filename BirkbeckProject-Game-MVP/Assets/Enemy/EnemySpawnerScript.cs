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
    internal EnemyDataScriptableObject enemyData;

    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    internal int enemySpawnRate;

    [SerializeField]
    internal bool spawnOnStartUp = true;

    public bool enemyCountAboveBoundary;
    public bool enemyCountAtMax;
    public int enemyCount;

    private void Start()
    {
        // Set up variables required for class functionality
        enemyCountAtMax = false;

        // Spawn an enemy straight away if conditions met
        if (spawnOnStartUp) GameObject.Instantiate(enemyPrefab, transform.localPosition, Quaternion.identity);

        // Start ongoing coroutine
        StartCoroutine(SpawnAnEnemyEvertXSeconds());
    }

    private void Update()
    {
        KeepTrackOfEnemyDataVariables();
    }

    private void KeepTrackOfEnemyDataVariables()
    {
        enemyCount = enemyData.GetEnemyCount();
        enemyCountAboveBoundary = (enemyData.GetEnemyCount() >= enemyData.GetBehaviourChangePoint());
        enemyCountAtMax = (enemyData.GetEnemyCount() >= enemyData.GetEnemyCountMax());
    }

    private IEnumerator SpawnAnEnemyEvertXSeconds()
    {
        if (enemyCountAboveBoundary) yield return new WaitForSeconds(enemySpawnRate * 2);
        else yield return new WaitForSeconds(enemySpawnRate);

        if (!enemyCountAtMax) GameObject.Instantiate(enemyPrefab, transform.localPosition, Quaternion.identity);
        StartCoroutine(SpawnAnEnemyEvertXSeconds());
    } 
}
