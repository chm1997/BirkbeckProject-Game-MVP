using System.Collections.Generic;

public enum NodeState
{
    RUNNING,
    SUCCESS,
    FAILURE
}

public class BehaviourNode
{
    /// <summary>
    /// This class is an implementation of a generic Node component of the behaviour tree data structure.
    /// It is designed to be overwritten to introduce specific behaviours, while having access to the NodeState enum and the basic functionality of its methods.
    /// </summary>
    
    public NodeState state;
    public BehaviourNode parent;
    public List<BehaviourNode> children = new List<BehaviourNode>();

    public Dictionary<string, object> data = new Dictionary<string, object>();

    public virtual NodeState Evaluate() => NodeState.FAILURE;

    public BehaviourNode()
    {
        parent = null;
    }

    public BehaviourNode(List<BehaviourNode> children)
    {
        //This constructor enabled BehaviourNode instances to act as non-leaf nodes that reference others
        foreach (BehaviourNode child in children) Attach(child);
    }

    public void Attach(BehaviourNode behaviourNode)
    {
        // Helper method for List constructor
        behaviourNode.parent = this;
        children.Add(behaviourNode);
    }

    public void SetData(string key, object value)
    {
        // This method allows data to be set in the BehaviourNode's dictionary
        data[key] = value;
    }

    public object GetData(string key)
    {
        // This method allows data to be recieved from the BehaviourNode's dictionary
        object returnValue = null;

        if (data.TryGetValue(key, out returnValue)) return returnValue;

        BehaviourNode behaviourNode = parent;

        if (behaviourNode != null)
        {
            returnValue = behaviourNode.GetData(key);
        }

        return returnValue;
    }

    public bool ClearData(string key)
    {
        // This method allows data to be deleted from the BehaviourNode's dictionary
        bool returnBool = false;

        if (data.ContainsKey(key))
        {
            data.Remove(key);
            return true;
        }

        BehaviourNode behaviourNode = parent;

        if (behaviourNode != null) returnBool = behaviourNode.ClearData(key);

        return returnBool;
    }
}
