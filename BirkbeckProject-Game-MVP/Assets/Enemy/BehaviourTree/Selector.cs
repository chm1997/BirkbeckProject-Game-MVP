using System.Collections.Generic;

public class Selector : BehaviourNode
{
    /// <summary>
    /// This implementation of the BehaviourNode is meant to act as a container for other Node implementations in order to control the flow of actions.
    /// This class calls the Evaluate() method on contained classes until one returns a Running or Success NodeState, at which point it stops processing
    /// </summary>
    
    public Selector() : base() { }
    public Selector(List<BehaviourNode> children) : base(children) { }

    public override NodeState Evaluate()
    {
        foreach (BehaviourNode behaviourNode in children)
        {
            switch (behaviourNode.Evaluate())
            {
                case NodeState.FAILURE: continue;
                case NodeState.SUCCESS: return NodeState.SUCCESS;
                case NodeState.RUNNING: return NodeState.RUNNING;
                default: continue;
            }
        }
        return NodeState.FAILURE;
    }
}
