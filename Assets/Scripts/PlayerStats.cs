using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI HP;
    [SerializeField] private TextMeshProUGUI AT;
    [SerializeField] private TextMeshProUGUI DEF;
    [SerializeField] private TextMeshProUGUI nextLevelEXPUI;
    [SerializeField] private TextMeshProUGUI EXP;
    private Digimon player;

    private void Start()
    {
        player = GameManager.instance.player.GetComponent<Digimon>();
        UpdateUI();
        
    }

    public void UpdateUI()
    {
        
        HP.text = player.HP.ToString();
        AT.text = player.AT.ToString();
        DEF.text = player.DEF.ToString();
        EXP.text = GameManager.instance.EXP.ToString();
        nextLevelEXPUI.text = GameManager.instance.costLevelUp.ToString();
        // EXP.text = GameManager.instance.EXP.ToString();
        // nextLevelEXPUI.text = GameManager.instance.costLevelUp.ToString();
    }

    public void LevelUp()
    {
        GameManager.instance.LevelUp(); 
        UpdateUI();
    }

    
    
    
}
