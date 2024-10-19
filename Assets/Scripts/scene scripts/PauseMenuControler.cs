using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuPanel;
    public string mainMenuSceneName = "MainMenu";
    public Inventory PlayerInventory; 
    public GameObject FinishScreenPanel;
    public string ShellKey = "Shells";
    public int TotalShells;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        {
            CheckShellCount();
        }
    }

    public void Resume()
    {
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenuSceneName);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void CheckShellCount()
    {
        string ShellKey = "Shells";
        if (PlayerInventory.inventory.ContainsKey(ShellKey))
        {
            if (PlayerInventory.inventory[ShellKey] >= TotalShells)
            {
                TriggerFinishScreen();
            }
        }
        else
        {
            Debug.LogWarning("Shells not found in inventory.");
        }
    }

    void TriggerFinishScreen()
    {
        FinishScreenPanel.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

}
