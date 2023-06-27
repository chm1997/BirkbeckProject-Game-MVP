using UnityEngine;

public class EnemyScript : MonoBehaviour, IDamagingObject, IEnemy
{
    [SerializeField]
    private EnemyDataScriptableObject enemyData;
    public bool isDamaging { get; set; }
    public int damageValue { get; set; }

    private void Start()
    {
        isDamaging = true;
        damageValue = 1;

        enemyData.IncreaseEnemyCount();
    }

    private void Update()
    {
        EnemyMovement();
    }

    private void EnemyMovement()
    {

    }
}
