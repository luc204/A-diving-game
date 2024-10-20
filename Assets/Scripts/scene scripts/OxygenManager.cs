using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OxygenManager : MonoBehaviour
{
    public Slider oxygenSlider;
    public float maxOxygen = 60f;
    public float oxygenDepletionRate = 1f;
    public GameObject deathScreenPanel;

    private float currentOxygen;

    void Start()
    {
        currentOxygen = maxOxygen;
        if (oxygenSlider != null)
        {
            oxygenSlider.maxValue = maxOxygen;
            oxygenSlider.value = maxOxygen;
        }
        if (deathScreenPanel != null)
        {
            deathScreenPanel.SetActive(false);
        }
    }

    void Update()
    {
        if (currentOxygen > 0)
        {
            currentOxygen -= oxygenDepletionRate * Time.deltaTime;
            currentOxygen = Mathf.Max(currentOxygen, 0f);

            if (oxygenSlider != null)
            {
                oxygenSlider.value = currentOxygen;
            }
        }
        else
        {
            ShowDeathScreen();
        }
    }

    void ShowDeathScreen()
    {
        if (deathScreenPanel != null)
        {
            deathScreenPanel.SetActive(true);
        }
        Time.timeScale = 0f; // Pause the game
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; //resume game or like put back to normal time
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
