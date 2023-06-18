using UnityEngine.SceneManagement;
using UnityEngine;

public class RestartButton : MonoBehaviour
{
    public void OnPressed()
    {
        SceneManager.LoadScene("DesertScene");
    }
}
