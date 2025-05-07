using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuCanvas : MonoBehaviour
{
    [SerializeField] private GameObject playerStatsMenu;
    [SerializeField] private GameObject rivalStatsMenu;
    [SerializeField] private GameObject playerStatsButton;
    [SerializeField] private GameObject rivalStatsButton;
    [SerializeField] private GameObject arenaButton;
    [SerializeField] private GameObject tapirmonButton;
    [SerializeField] private GameObject confirmArena;

   
    public void OnChangeMenu()
    {
        Debug.Log("changeMenu");
        if (playerStatsMenu.activeSelf)
        {
            ClosePlayerStats();
            OpenRivalStats();
        }
        else
        {
            CloseRivalStats();
            OpenPlayerStats();
        }
    }

    public void CloseMenu()
    {
        CloseRivalStats();
        ClosePlayerStats();
        CloseArena();
    }
     
    private void OpenPlayerStats()
    {
        playerStatsMenu.SetActive(true);
    }
    private void ClosePlayerStats()
    {
        playerStatsMenu.SetActive(false);
    }
    private void OpenRivalStats()
    {
        rivalStatsMenu.SetActive(true);
    }
    private void CloseRivalStats()
    {
        rivalStatsMenu.SetActive(false);
    }
 
  

    public void ArenaStart()
    {
        confirmArena.SetActive(true);
    }

    private void CloseArena()
    {
        confirmArena.SetActive(false);
    }

    public void StartCombat()
    {
        SceneManager.LoadScene("BattleScene");
    }
    
}
