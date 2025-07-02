using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleCanvas : MonoBehaviour
{
    public GameObject WinScreen;
    public GameObject DefeatScreen;
    public Button atk;
    public Button heal;
    
    public TextMeshProUGUI rivalName;
    public TextMeshProUGUI rivalHP;
    public TextMeshProUGUI playerName;
    public TextMeshProUGUI playerHP;
    public TextMeshProUGUI COMBAT_LOG;

    public CanvasGroup buttons;
    public CanvasGroup battleInfo;
    public CanvasGroup endBattle;

    [SerializeField] private BattleManager _battleManager; 
    
    
    
    public void EndCombat(bool win)
    {
        buttons.alpha = 0;
        buttons.interactable = false;
        battleInfo.alpha = 0;
        battleInfo.interactable=false;
        
        endBattle.alpha = 1;
        endBattle.interactable = true;
        //Buttons.SetActive(false);
        if (win)
        {
            WinScreen.SetActive(true);
        }
        else
        {
            DefeatScreen.SetActive(true);
        }
    }

    public void SetupCanvas(string rival, string player)
    {
        rivalName.text = rival;
        playerName.text = player;
        atk.onClick.AddListener(_battleManager.Attack);
        heal.onClick.AddListener(_battleManager.Heal);

    }
    public void UpdateHP_Player(int newHP)
    {
        playerHP.text = newHP.ToString();
    }
    
    public void UpdateHP_Rival(int newHP)
    {
        rivalHP.text = newHP.ToString();
    }

    public void SetLogs(string text)
    {
        COMBAT_LOG.text = text;
    }

    public void Continue()
    {
        GameManager.instance.returnMainIsland();
    }


}
