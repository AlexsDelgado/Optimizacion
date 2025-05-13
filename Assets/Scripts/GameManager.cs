using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject player;
    public GameObject[] rival;
    public GameObject actualRival;

    public int EXP = 0;
    public int gold = 0;
    private int costLevelUp;
    private int costUnlockCombat;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void returnMainIsland()
    {
        SceneManager.LoadScene("Main Scene");
        
    }

    public void SetRivalArena(int id)
    {
        actualRival = rival[id];
    }
}
