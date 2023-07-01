using System.Collections.Generic;

public class Sequence : BehaviourNode
{
    /// <summary>
    /// This implementation of the BehaviourNode is meant to act as a container for other Node implementations in order to control the flow of actions.
    /// This class calls the Evaluate() method on contained classes until one returns a Failure NodeState, at which point it stops processing
    /// </summary>
    
    public Sequence() : base() { }
    public Sequence(List<BehaviourNode> children) : base(children) { }

    public override NodeState Evaluate()
    {
        bool childRunning = false;

        foreach(BehaviourNode behaviourNode in children)
        {
            switch (behaviourNode.Evaluate())
            {
                case NodeState.FAILURE: return NodeState.FAILURE;
                case NodeState.SUCCESS: continue;
                case NodeState.RUNNING: childRunning = true; continue;
                default: return NodeState.SUCCESS;
            }
        }
        return childRunning ? NodeState.RUNNING : NodeState.SUCCESS;
    }
}
