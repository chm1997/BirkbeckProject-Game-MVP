using UnityEngine;

public abstract class BehaviourTree : MonoBehaviour
{
    /// <summary>
    /// This is an abstract class to support implementations of the behaviour tree design pattern for implemented game objects
    /// </summary>

    internal BehaviourNode rootNode = null;

    private void Start()
    {
        rootNode = SetupBehaviourTree();
    }

    private void Update()
    {
        if (rootNode != null) rootNode.Evaluate();
    }

    internal abstract BehaviourNode SetupBehaviourTree();
}
