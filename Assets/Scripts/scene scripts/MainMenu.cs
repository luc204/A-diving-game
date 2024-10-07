using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void SceneChange()
    {
        //load scene
        SceneManager.LoadScene("Game");

        //quit game

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
