using UnityEngine.SceneManagement;
using UnityEngine;

public class RestartButton : MonoBehaviour
{
    /// <summary>
    /// This class loads the main game scene when associated button object is pressed
    /// </summary>
    
    public void OnPressed()
    {
        //This method is called by the scene when the button object is pressed, loading the desert scene
        SceneManager.LoadScene("DesertScene");
    }
}
