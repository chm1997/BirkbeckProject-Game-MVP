using UnityEngine;

public class EnemyScript : MonoBehaviour, IDamagingObject, IEnemy
{
    /// <summary>
    /// This class handles core enemy functions such as damage values and physics interactions. Movement Behaviour is handled seperately
    /// Required Fields:
    /// EnemyDataScriptableObject enemyData: a Scriptable Object containing various data about enemies in the game space
    /// </summary>

    public bool isDamaging { get; set; }
    public int damageValue { get; set; }

    [SerializeField]
    internal EnemyDataScriptableObject enemyData;

    private GameObject player;

    private Rigidbody2D rb2d;

    public Collider2D hitCollider;

    public Vector2 targetVector;
    public Vector2 currentPos;
    public Vector2 direction;

    private void Start()
    {
        // Set up variables required for class functionality
        isDamaging = true;
        damageValue = 1;

        enemyData.IncreaseEnemyCount();

        player = GameObject.FindWithTag("Player");

        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        currentPos = new Vector2(transform.position.x, transform.position.y);
        targetVector = player.transform.position;   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Player")
        {
            if (collision.collider.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("penguin_attack"))
            {
                enemyData.DecreaseEnemyCount();
                GameObject.Destroy(gameObject);
            }
            else
            {
                rb2d.velocity = Vector2.zero;
                direction = targetVector - currentPos;
                rb2d.AddForce(direction * -1 * 100);
            }
        }
    }
}
