using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattleCanvas : MonoBehaviour
{
    public GameObject WinScreen;
    public GameObject DefeatScreen;
    public GameObject Buttons;
    public TextMeshProUGUI rivalName;
    public TextMeshProUGUI rivalHP;
    public TextMeshProUGUI playerName;
    public TextMeshProUGUI playerHP;
    public TextMeshProUGUI COMBAT_LOG;
    
    
    public void EndCombat(bool win)
    {
        Buttons.SetActive(false);
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
