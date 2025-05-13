using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    
    
    
    
    public void CustomUpdate()
    {
        if (actualTurnTime<turnTime)
        {
            actualTurnTime += Time.deltaTime;
        }
        else
        {
            actualTurnTime= 0;
            if (playerTurn)
            {
                playerTurn = false;
            }
            else
            {
                playerTurn = true;
            }

            turnCount++;
            Debug.Log("Turn "+ turnCount +" ended -> player can move: \n" + playerTurn );
        }
    }
    void Awake()
    {
        CustomUpdateManager.Instance.AddToList(this);
        //Debug.Log("Battle Manager AWKAE");
        turnCount = 0;
        startCombat();
    }

    public void startCombat()
    {
        //gamemanager.instance.player
        //gamemanager.instance.rival
        playerGO= Instantiate(GameManager.instance.player, playerPos);
        rivalGO=Instantiate(GameManager.instance.actualRival, rivalPos);
        
       
        
        playerGO.transform.position = playerPos.position;
        
        //rivalGO.transform.position = rivalPos.position;
        rival = rivalGO.GetComponent<Digimon>();
        player = playerGO.GetComponent<Digimon>();
    }

    public void Attack()
    {
        if (playerTurn)
        {
            playerGO.GetComponent<Animator>().Play("attack1");
        }
        else
        {
            Debug.Log("Player cannot move");
        }
    }
    public void Skill()
    {
        if (playerTurn)
        {
            playerGO.GetComponent<Animator>().Play("attack2");
        }
        else
        {
            Debug.Log("Player cannot move");
        }
    }
    
}
