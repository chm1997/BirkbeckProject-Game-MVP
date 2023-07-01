using UnityEngine;

public class Attack : BehaviourNode
{
    /// <summary>
    /// This class implements BehaviourNode in order to add set force to the enemy object this script is attached to when conditions are met
    /// Required Fields:
    /// Transform targetTransform: the Transform component of the object being targetted to move towards
    /// Transform enemyTransform: the Transform component of the enemy object this script is attached to
    /// Rigidbody2D enemyRB2d: the Rigidbody2D component of the enemy object this script is attached to
    /// </summary>

    private Transform objectTransform;
    private Rigidbody2D objectRB2D;

    private Transform targetTransform;

    private Animator animator;

    private Vector2 direction;

    private bool hasAttacked;

    public Attack(Transform objectTransform, Rigidbody2D objectRB2D, Animator animator)
    {
        this.objectTransform = objectTransform;
        this.objectRB2D = objectRB2D;
        this.animator = animator;
    }

    public override NodeState Evaluate()
    {
        if (parent.parent.GetData("hasAttacked") != null) hasAttacked = (bool)parent.parent.GetData("hasAttacked");

        object target = parent.parent.GetData("target");

        if (!hasAttacked & target != null)
        {
            animator.Play("EnemyAttack");
            targetTransform = (Transform)target;
            parent.parent.SetData("hasAttacked", true);
            direction = targetTransform.position - objectTransform.position;
            objectRB2D.AddForce(direction * 100);
        }
        return NodeState.SUCCESS;
    }
}
