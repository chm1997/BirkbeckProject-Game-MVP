using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneContolScript : MonoBehaviour
{
    public PlayerHealth playerHealth;
    void Update()
    {
        if (playerHealth.GetPlayerHealth() <= 0) LoadDeathScene();
    }

    private void LoadDeathScene()
    {
        SceneManager.LoadScene("Game Over Scene");
    }
}
