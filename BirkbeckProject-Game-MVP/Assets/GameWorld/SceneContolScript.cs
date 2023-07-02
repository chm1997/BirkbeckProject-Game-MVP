using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneContolScript : MonoBehaviour
{
    /// <summary>
    /// This class handles the change of scene to the game over screen when player health reaches zero
    /// Required Fields:
    /// PlayerDataScriptableObject playerData: a Scriptable Object containing an int variable representing player data
    /// </summary>

    [SerializeField]
    internal PlayerDataScriptableObject playerData;
    
    private void Update()
    {
        if (playerData.GetPlayerHealth() <= 0) LoadDeathScene();
    }

    private void LoadDeathScene()
    {
        SceneManager.LoadScene("Game Over Scene");
    }
}
