using System;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuCanvas : MonoBehaviour
{

    [SerializeField] private CanvasGroup playerStatsMenu;
    [SerializeField] private CanvasGroup rivalStatsMenu;
    [SerializeField] private CanvasGroup confirmArena;
    
    [SerializeField] private Button playerStatsButton;
    [SerializeField] private Button rivalStatsButton;
    [SerializeField] private Button arenaButton;
    [SerializeField] private Button backMainMenuButton;
    [SerializeField] private Button closeRival;
    [SerializeField] private Button closeDigimon;
    [SerializeField] private Button closeArena;
    [SerializeField] private Button confirmArenaButton;
    
    
    
    
    [SerializeField] private GameObject Digimon0;
    [SerializeField] private GameObject Digimon1;
    [SerializeField] private Button Digimon0Selection;
    [SerializeField] private Button Digimon1Selection;
    [SerializeField] private TextMeshProUGUI RivalName;
    
    [SerializeField] private TextMeshProUGUI HP;
    [SerializeField] private TextMeshProUGUI AT;
    [SerializeField] private TextMeshProUGUI Difficulty;
    [SerializeField] private TextMeshProUGUI Name;

    private void Awake()
    {
        playerStatsButton.onClick.AddListener(OnChangeMenu);
        rivalStatsButton.onClick.AddListener(OnChangeMenu);
        arenaButton.onClick.AddListener(OpenArenaMenu);
        Digimon0Selection.onClick.AddListener(SetRival0);
        Digimon1Selection.onClick.AddListener(SetRival1);
        
        closeArena.onClick.AddListener(CloseArena);
        closeDigimon.onClick.AddListener(CloseMenu);
        closeRival.onClick.AddListener(CloseRivalStats);
        
        backMainMenuButton.onClick.AddListener(ReturnMenu);

        confirmArenaButton.onClick.AddListener(StartCombat);
        
        startGame();
    }

    
    public void UpdateStatsRival()
    {
        
        Digimon rival = GameManager.instance.actualRival.GetComponent<Digimon>();
        HP.text= rival.HP.ToString();
        AT.text = rival.AT.ToString();
        Difficulty.text = rival.rewardEXP.ToString();
        Name.text = rival.DigimonName;
        // EXP.text = GameManager.instance.EXP.ToString();
        // nextLevelEXPUI.text = GameManager.instance.costLevelUp.ToString();
    }
    public void SetRival0()
    {
        GameManager.instance.actualRival = GameManager.instance.rival[0];
        UpdateStatsRival();
    }
    public void SetRival1()
    {
        GameManager.instance.actualRival = GameManager.instance.rival[1];
        UpdateStatsRival();
    }
    public void startGame()
    {
        GameManager.instance.StartGame();
    }
    public void OnChangeMenu()
    {
        
        if (playerStatsMenu.alpha>0)
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
        playerStatsMenu.alpha = 1;
        playerStatsMenu.interactable = true;

    }
    private void ClosePlayerStats()
    {
        playerStatsMenu.alpha = 0;
        playerStatsMenu.interactable = false;
    }
    private void OpenRivalStats()
    {
        rivalStatsMenu.alpha=1;
        rivalStatsMenu.interactable=true;
        
        Digimon0.SetActive(true);
        //Digimon0Selection.SetActive(true);
        Digimon0Selection.interactable=true;
        Digimon1.SetActive(true);
        Digimon1Selection.interactable=true;
    }
    private void CloseRivalStats()
    {
        
        rivalStatsMenu.alpha = 0;
        rivalStatsMenu.interactable = false;
        Digimon0.SetActive(false);
        Digimon0Selection.interactable=false;
        
        Digimon1.SetActive(false);
        Digimon1Selection.interactable=false;
    }
    public void OpenArenaMenu()
    {
        confirmArena.alpha = 1;
        confirmArena.interactable = true;
        
        RivalName.text = GameManager.instance.actualRival.name;
        ClosePlayerStats();
        CloseRivalStats();
    }
    private void CloseArena()
    {
        confirmArena.alpha=0;
        confirmArena.interactable = false;
    }
    public void StartCombat()
    {
        GameManager.instance.LoadSceneCombat();
        
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
}
