using UnityEngine;

public class CircleTarget : BehaviourNode
{
    /// <summary>
    /// This class implements BehaviourNode in order to position the object in the space above a (potentially moving) target position
    /// Required Fields:
    /// Transform targetTransform: the Transform component of the object being targetted to move towards
    /// Transform enemyTransform: the Transform component of the enemy object this script is attached to
    /// Rigidbody2D enemyRB2d: the Rigidbody2D component of the enemy object this script is attached to
    /// float speed: a variable determining the speed at which the enemy object this sript is attached to moves towards the target
    /// float radiusAboveTarget: a variable determining how large a radius above the target position to draw locations to move towards from
    /// </summary>

    private Transform targetTransform;
    private Transform objectTransform;
    private Rigidbody2D rb2D;
    private float speed;
    private float radiusAboveTarget;

    private bool firstTick;

    private Vector2 targetPosition;
    internal Vector2 pointAboveTarget;
    internal Vector2 currentPos;

    public CircleTarget(Transform targetTransform, Transform objectTransform, Rigidbody2D rb2D, float speed, float radiusAboveTarget)
    {
        // Set up variables required for class functionality
        this.targetTransform = targetTransform;
        this.objectTransform = objectTransform;
        this.rb2D = rb2D;
        this.speed = speed;
        this.radiusAboveTarget = radiusAboveTarget;

        firstTick = true;
    }

    public override NodeState Evaluate()
    {
        rb2D.velocity = Vector2.zero;
        targetPosition = targetTransform.position;
        currentPos = new Vector2(objectTransform.position.x, objectTransform.position.y);

        if (firstTick)
        {
            ChooseNewPositionAbovePlayer();
            firstTick = false;
        }

        if (currentPos == pointAboveTarget) ChooseNewPositionAbovePlayer();
        objectTransform.position = Vector2.MoveTowards(currentPos, pointAboveTarget, speed * Time.deltaTime);

        return NodeState.RUNNING;
    }

    private void ChooseNewPositionAbovePlayer()
    {
        // Helper method for Evaluate() that picks a random position in a semi-circle above the target location
        Vector2 randomCirclePosition = Random.insideUnitCircle * radiusAboveTarget;
        Vector2 randomCirclePosiitonPositive = new Vector2(randomCirclePosition.x, Mathf.Abs(randomCirclePosition.y));
        pointAboveTarget = randomCirclePosiitonPositive + targetPosition;
    }
}
