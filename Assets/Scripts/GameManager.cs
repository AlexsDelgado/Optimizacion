using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public int costLevelUp = 5;
    private int costUnlockCombat;
    public bool newGame = true;

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

    public void StartGame()
    {
        if (newGame)
        {
            actualRival = rival[0];
            player.GetComponent<Digimon>().ResetStats();
            newGame = false;
               
        }
        else
        {
            Debug.Log("etnro else");
        }
    }
    public void returnMainIsland()
    {
        SceneManager.LoadScene("Main Scene");
        
    }

    public void SetRivalArena(int id)
    {
        actualRival = rival[id];
    }

    public void LevelUp()
    {
        if (EXP >= costLevelUp)
        {
            Digimon playerStats = player.GetComponent<Digimon>();
            playerStats.AT += playerStats.AT;
            playerStats.DEF += playerStats.DEF;
            playerStats.HP += playerStats.HP/2;
            costLevelUp= costLevelUp*2;
            Debug.Log("Update level up");
        }
        else
        {
            Debug.Log("Not Enough EXP");
        }
    }
}
