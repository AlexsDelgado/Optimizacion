using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour, IUpdate
{
    [SerializeField] private bool playerTurn;
    [SerializeField] private int turnCount;
    [SerializeField] private float actualTurnTime;
    [SerializeField] private float turnTime;
    [SerializeField] private GameObject playerGO;
    private Digimon player;
    private Digimon rival;
    [SerializeField] private GameObject rivalGO;
    [SerializeField] private Transform playerPos;
    [SerializeField] private Transform rivalPos;
    [SerializeField] private Transform AttackPos;
    [SerializeField] private BattleCanvas UI;
    private bool action =true;
    
    
    
    public void CustomUpdate()
    {
        if (actualTurnTime<turnTime)
        {
            actualTurnTime += Time.deltaTime;
        }
        else
        {
            actualTurnTime= 0;
            //check si se encuentra el turno del player
            if (playerTurn)
            {
                playerTurn = false;
                RivalTurn();
                
            }
            else
            {
                playerTurn = true;
                action = true;
            }
            turnCount++;
            
        }
    }


    void Awake()
    {
        CustomUpdateManager.Instance.AddToList(this);
        
        turnCount = 0;
        StartCombat();
    }

    public void StartCombat()
    {
        playerGO= Instantiate(GameManager.instance.player, playerPos);
        rivalGO=Instantiate(GameManager.instance.actualRival, rivalPos);
        playerGO.transform.position = playerPos.position;
        rivalGO.transform.position = rivalPos.position;
        rival = rivalGO.GetComponent<Digimon>();
        player = playerGO.GetComponent<Digimon>();
        SetupCanvas();
        player.StartGameObject();
        rival.StartGameObject();
        
    }
    
    public void SetupCanvas()
    {
        UI.SetupCanvas(rival.DigimonName,player.DigimonName);
        UI.UpdateHP_Player(player.HP);
        UI.UpdateHP_Rival(rival.HP);
    }
    public void Attack()
    {
        if (playerTurn&&action)
        {
            player.Action();
            action = false;
            DoDamage();
            rival.Damage();
            UI.UpdateHP_Rival(rival.HP);
            UI.SetLogs(player.DigimonName+" attack and deals " + player.AT + " damage.");
            
        }
    
    }
    public void Skill()
    {
        if (playerTurn)
        {
            playerGO.GetComponent<Animator>().Play("Skill");
        }
    
    }

    public void Heal()
    {
        if (playerTurn)
        {
            player.HP += player.DEF;
            UI.UpdateHP_Player(player.HP);
            UI.SetLogs(player.DigimonName+" heals " + player.DEF + " HP.");
            action = false;

        }
  
    }
    public void RivalTurn()
    {
        rival.Action();
        GetDamage();
        player.Damage();
        UI.SetLogs(rival.DigimonName+" attack and deals " + rival.AT + " damage.");
        UI.UpdateHP_Player(player.HP);

    }

    public void DoDamage()
    {
        rival.HP = rival.HP - player.AT;
        if (rival.HP <= 0)
        {
            EndCombat(true);
        }
    }

    public void GetDamage()
    {
        player.HP = player.HP - rival.AT;
        if (player.HP <= 0)
        {
            EndCombat(false);
        }
    }

    public void EndCombat(bool win)
    {
        if (win)
        {
            GameManager.instance.EXP += rival.rewardEXP;
            player.Win();
            rival.Lose();
            UI.EndCombat(win);
        }
        else
        {
            player.Lose();
            rival.Win();
            UI.EndCombat(win);
        }
        CustomUpdateManager.Instance.RemoveFromUpdateList(this);
        //GameManager.instance.returnMainIsland();
    }
}
