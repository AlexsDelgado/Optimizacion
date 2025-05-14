using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Digimon : MonoBehaviour
{
    public string DigimonName;
    public int AT;
    public int DEF;
    public int HP;
    public int rewardEXP;
    private Animator animator;

    public void StartGameObject()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    public void Action()
    {
        animator.Play("Attack");
    }

    public void Damage()
    {
        animator.Play("Dmg");
    }

    public void ResetStats()
    {
        AT = 10;
        DEF = 10;
        HP = 80;
    }

    public void Win()
    {
        animator.Play("Win");
        
    }

    public void Lose()
    {
        animator.Play("Lose");
    }
}
