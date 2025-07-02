using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{
    public Button play;
    public Button quit;

    private void Awake()
    {
        play.onClick.AddListener(PlayButton);
        quit.onClick.AddListener(QuitGameButton);
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("Main Scene");
    }

    public void QuitGameButton()
    {
        Application.Quit();
    }
}
