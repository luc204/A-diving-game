using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleMenuController : MonoBehaviour
{
    public string gameSceneName = "Game"; 

    public void StartGame()
    {
        Debug.Log("Starting the game...");
        SceneManager.LoadScene(gameSceneName);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting the game...");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
