public class CheckEnemyNumbers : BehaviourNode
{
    /// <summary>
    /// This class implements BehaviourNode in order to act as a simple check for whether there are a certain number of enemy objects in the scene
    /// Required Fields:
    /// EnemyDataScriptableObject enemyData: a Scriptable Object containing various data about enemies in the game space
    /// </summary>

    private EnemyDataScriptableObject enemyData;
    public CheckEnemyNumbers(EnemyDataScriptableObject enemyData)
    {
        this.enemyData = enemyData;
    }

    public override NodeState Evaluate()
    {
        if (enemyData.GetEnemyCount() >= enemyData.GetBehaviourChangePoint()) return NodeState.RUNNING;
        return NodeState.FAILURE;
    }
}
