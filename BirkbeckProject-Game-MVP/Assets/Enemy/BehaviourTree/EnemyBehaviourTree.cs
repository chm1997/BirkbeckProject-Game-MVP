using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviourTree : BehaviourTree
{
    /// <summary>
    /// This class is an implementation of the abstract class BehaviourTree, representing the behaviour tree design pattern, meant for the enemy object.
    /// This class supports varied behaviours by cycling through states, as determined by supporting Node class implementations
    /// Required Fields:
    /// Transform enemyTransform:the Transform component of the enemy object this script is attached to
    /// Rigidbody2D enemyRB2d: the Rigidbody2D component of the enemy object this script is attached to
    /// EnemyDataScriptableObject enemyData: a Scriptable Object containing various data about enemies in the game space
    /// </summary>


    [SerializeField]
    private Transform enemyTransform;
    [SerializeField]
    private Rigidbody2D enemyRB2d;
    [SerializeField]
    private EnemyDataScriptableObject enemyData;

    private Animator animator;

    private Transform playerTransform;

    private void Awake()
    {
        // Set up variables required for class functionality
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        animator = GetComponent<Animator>();
    }

    internal override BehaviourNode SetupBehaviourTree()
    {
        // This method sets up the order of enemy behaviour states and, as a result, its behaviour in the game world
        BehaviourNode rootBehaviourNode = new Selector(new List<BehaviourNode>
        {
            new Sequence(new List<BehaviourNode>
            {
                new CheckEnemyNumbers(enemyData),
                new CircleTarget(playerTransform, enemyTransform, enemyRB2d, 7f, 10f)
            }),

            new Sequence(new List<BehaviourNode>
            {
                new CheckAttackCooldown(enemyRB2d, 1.25f),
                new CheckAttackRange(enemyTransform, 7f, 256),
                new Attack(enemyTransform, enemyRB2d, animator)
            }),
            new Track(playerTransform, enemyTransform, 4f)
        });
        return rootBehaviourNode;
    }
}
