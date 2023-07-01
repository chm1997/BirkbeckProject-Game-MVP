using UnityEngine;

public class CheckAttackRange : BehaviourNode
{
    /// <summary>
    /// This class implements BehaviourNode in order to check whether an object is within a certain radius, setting this object as the target object in the root data structure if it is
    /// Required Fields:
    /// Transform enemyTransform: the Transform component of the enemy object this script is attached to
    /// float checkRange: a variable determining how large an area around the enemy object this script is attached to is to be checked
    /// int layerNum: a variable determing which layer(s) should be considered when checking for objects in range
    /// </summary>


    private Transform objectTransform;
    private float checkRange;
    private int layerNum;

    private Collider2D hitCollider;

    private bool hasAttacked;
    

    public CheckAttackRange(Transform objectTransform, float checkRange, int layerNum)
    {
        this.objectTransform = objectTransform;
        this.checkRange = checkRange;
        this.layerNum = layerNum;
    }

    public override NodeState Evaluate()
    {
        hasAttacked = (bool)parent.parent.GetData("hasAttacked");
        
        if (!hasAttacked)
        {
            hitCollider = Physics2D.OverlapCircle(objectTransform.position, checkRange, layerNum);
            if (hitCollider != null)
            {
                parent.parent.SetData("target", hitCollider.transform);
            }
            else
            {
                parent.parent.ClearData("target");
                parent.parent.ClearData("hasAttacked");
                return NodeState.FAILURE;

            }
        }
        return NodeState.RUNNING;
    }
}
