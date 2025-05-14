using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("Main Scene");
    }

    public void QuitGameButton()
    {
        Application.Quit();
    }
}
