using UnityEngine;

[CreateAssetMenu(fileName = "New EnemyData", menuName = "Enemy Data", order = 103)]
public class EnemyDataScriptableObject : ScriptableObject
{
    private int enemyCount;
    private int enemyCountMax;
    private int enemyBehaviourChangePoint;

    private void OnEnable()
    {
        enemyCount = 0;
        enemyCountMax = 6;
        enemyBehaviourChangePoint = 4;
    }

    public int GetEnemyCount()
    {
        return enemyCount;
    }
    public void IncreaseEnemyCount()
    {
        enemyCount += 1;
    }

    public void DecreaseEnemyCount()
    {
        enemyCount -= 1;
    }

    public void ResetEnemyCount()
    {
        enemyCount = 0;
    }

    public int GetEnemyCountMax()
    {
        return enemyCountMax;
    }
    public void SetEnemyCountMax(int incomingChange)
    {
        enemyCountMax = incomingChange;
    }
    public void UpdateEnemyCountMax(int incomingChange)
    {
        enemyCountMax += incomingChange;
    }

    public int GetBehaviourChangePoint()
    {
        return enemyBehaviourChangePoint;
    }
    public void SetBehaviourChangePoint(int incomingChange)
    {
        enemyBehaviourChangePoint = incomingChange;
    }
    public void UpdateBehaviourChangePointy(int incomingChange)
    {
        enemyBehaviourChangePoint += incomingChange;
    }

}
