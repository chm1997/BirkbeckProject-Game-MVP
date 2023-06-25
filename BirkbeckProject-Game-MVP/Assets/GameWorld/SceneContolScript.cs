using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneContolScript : MonoBehaviour
{
    /// <summary>
    /// This class handles the change of scene to the game over screen when player health reaches zero
    /// Required Fields:
    /// PlayerHealth playerHealth: a Scriptable Object containing an int variable representing player health
    /// </summary>

    [SerializeField]
    internal PlayerHealth playerHealth;
    
    private void Update()
    {
        if (playerHealth.GetPlayerHealth() <= 0) LoadDeathScene();
    }

    private void LoadDeathScene()
    {
        SceneManager.LoadScene("Game Over Scene");
    }
}
