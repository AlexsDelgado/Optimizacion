using System;
using TMPro;
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
    [SerializeField] private GameObject Digimon0;
    [SerializeField] private GameObject Digimon1;
    [SerializeField] private GameObject Digimon0Selection;
    [SerializeField] private GameObject Digimon1Selection;
    [SerializeField] private TextMeshProUGUI RivalName;
    
    

   
    public void OnChangeMenu()
    {
        Debug.Log("changeMenu");
        if (playerStatsMenu.activeSelf)
        {
            ClosePlayerStats();
            OpenRivalStats();
            CloseArena();
        }
        else
        {
            CloseRivalStats();
            OpenPlayerStats();
            CloseArena();
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
        Digimon0.SetActive(true);
        Digimon0Selection.SetActive(true);
        Digimon1.SetActive(true);
        Digimon1Selection.SetActive(true);
    }
    private void CloseRivalStats()
    {
        rivalStatsMenu.SetActive(false);
        Digimon0.SetActive(false);
        Digimon0Selection.SetActive(false);
        
        Digimon1.SetActive(false);
        Digimon1Selection.SetActive(false);
    }
    public void OpenArenaMenu()
    {
        confirmArena.SetActive(true);
        RivalName.text = GameManager.instance.actualRival.name;
        ClosePlayerStats();
        CloseRivalStats();
    }
    private void CloseArena()
    {
        confirmArena.SetActive(false);
    }
    public void StartCombat()
    {
        SceneManager.LoadScene("BattleScene");
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
}
