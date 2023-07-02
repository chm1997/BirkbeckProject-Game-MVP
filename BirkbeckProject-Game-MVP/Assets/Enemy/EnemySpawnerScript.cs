using System.Collections;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour, IInteractableObject
{
    /// <summary>
    /// This class handles the creation of enemy objects based on their prefab and a variable timer
    /// Required Fields:
    /// EnemyDataScriptableObject enemyData: a Scriptable Object containing various data about enemies in the game space
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
    internal bool spawnOnStartUp;

    private bool enemyCountAboveBoundary;
    private bool enemyCountAtMax;
    private int enemyCount;

    private void Start()
    {
        // Set up variables required for class functionality
        enemyData.ResetEnemyCount();
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
        // This method updates local variables to match global records of enemyData object
        enemyCount = enemyData.GetEnemyCount();
        enemyCountAboveBoundary = (enemyCount >= enemyData.GetBehaviourChangePoint());
        enemyCountAtMax = (enemyCount >= enemyData.GetEnemyCountMax());
    }

    private IEnumerator SpawnAnEnemyEvertXSeconds()
    {
        // This method creates a new enemy object at a time interval based on the spawn rate variable, how many enemies already exist in the game world, and what the maximum/boundary values are
        if (enemyCountAboveBoundary) yield return new WaitForSeconds(enemySpawnRate * 2);
        else yield return new WaitForSeconds(enemySpawnRate);

        if (!enemyCountAtMax) GameObject.Instantiate(enemyPrefab, transform.localPosition, Quaternion.identity);
        StartCoroutine(SpawnAnEnemyEvertXSeconds());
    }

    public void RecieveMessage(string message)
    {
        GameObject.Destroy(gameObject);
    }
}
