using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishScreenPanel : MonoBehaviour
{
    public Text shellsCollectedText;
    public Button replayButton;
    public Button mainMenuButton;

    private void Start()
    {
        // Hide the panel at the start of the game
        gameObject.SetActive(false);

        // Add listeners to the buttons
        replayButton.onClick.AddListener(ReplayGame);
        mainMenuButton.onClick.AddListener(GoToMainMenu);
    }

    public void ShowFinishScreen(int shellsCollected)
    {
        // Update the text to show the number of shells collected
        shellsCollectedText.text = "Shells Collected: " + shellsCollected;

        // Show the panel
        gameObject.SetActive(true);
    }

    private void ReplayGame()
    {
        // Reload the current scene to restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void GoToMainMenu()
    {
        // Load the main menu scene
        // Make sure to replace "MainMenu" with the actual name of your main menu scene
        SceneManager.LoadScene("MainMenu");
    }
}
