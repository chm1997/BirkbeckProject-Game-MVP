using UnityEngine;

public class CheckAttackCooldown : BehaviourNode
{
    /// <summary>
    /// This class implements BehaviourNode in order to check if an attack has taken place and whether it has been long enough since that attack to be able to make another one
    /// Required Fields:
    /// Rigidbody2D enemyRB2d: the Rigidbody2D component of the enemy object this script is attached to
    /// float waitTime: a variable used to determine how much time should elapse before an attack can be made again
    /// </summary>

    private Rigidbody2D enemyRB2D;

    private float waitTime;
    internal float waitCounter = 0f;
    private bool hasAttacked = false;

    public CheckAttackCooldown(Rigidbody2D enemyRB2D, float waitTime)
    {
        this.enemyRB2D = enemyRB2D;
        this.waitTime = waitTime;
    }

    public override NodeState Evaluate()
    {
        object _hasAttacked = parent.parent.GetData("hasAttacked");
        if (_hasAttacked == null)
        {
            parent.parent.SetData("hasAttacked", false);
            hasAttacked = false;
        }
        else hasAttacked = (bool)_hasAttacked;

        if (hasAttacked)
        {
            waitCounter += Time.deltaTime;
            if (waitCounter >= waitTime)
            {
                enemyRB2D.velocity = Vector2.zero;
                waitCounter = 0f;
                parent.parent.SetData("hasAttacked", false);
            }
        }
        return NodeState.RUNNING;
    }
}
