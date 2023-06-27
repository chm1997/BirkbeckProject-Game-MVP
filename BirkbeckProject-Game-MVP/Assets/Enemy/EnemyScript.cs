using UnityEngine;

public class EnemyScript : MonoBehaviour, IDamagingObject, IEnemy
{
    [SerializeField]
    private EnemyDataScriptableObject enemyData;

    private GameObject player;

    public Vector2 targetVector;

    public bool isDamaging { get; set; }
    public int damageValue { get; set; }

    private bool AboveChangePoint;

    private void Start()
    {
        isDamaging = true;
        damageValue = 1;

        enemyData.IncreaseEnemyCount();

        AboveChangePoint = false;

        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        targetVector = player.transform.position;
        EnemyMovement();
    }

    private void EnemyMovement()
    {
        if (enemyData.GetEnemyCount() >= enemyData.GetBehaviourChangePoint()) GroupMovement();
        else SingularMovement();
    }

    private void SingularMovement()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetVector, 3f * Time.deltaTime);
    }

    private void GroupMovement()
    {

    }
}
