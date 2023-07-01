using UnityEngine;

public class Track : BehaviourNode
{
    /// <summary>
    /// This class implements BehaviourNode in order to position the object in the space above a (potentially moving) target position
    /// Required Fields:
    /// Transform targetTransform: the Transform component of the object being targetted to move towards
    /// Transform enemyTransform: the Transform component of the enemy object this script is attached to
    /// float speed: a variable determining the speed at which the enemy object this sript is attached to moves towards the target
    /// </summary>

    private Transform targetTransform;
    private Transform enemyTransform;
    private float speed;

    private Vector2 currentPos;
    private Vector2 targetVector;

    public Track(Transform targetTransform, Transform enemyTransform, float speed)
    {
        this.targetTransform = targetTransform;
        this.enemyTransform = enemyTransform;
        this.speed = speed;
    }

    public override NodeState Evaluate()
    {
        currentPos = new Vector2(enemyTransform.transform.position.x, enemyTransform.transform.position.y);
        targetVector = targetTransform.position;
        enemyTransform.transform.position = Vector2.MoveTowards(currentPos, targetVector, speed * Time.deltaTime);

        return NodeState.RUNNING;
    }
}
