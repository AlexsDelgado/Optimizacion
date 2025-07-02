// using System.Collections;
// using System.Collections.Generic;
// using TMPro;
// using UnityEngine;
//
// public class RivalStats : MonoBehaviour
// {
//     [SerializeField] private TextMeshProUGUI HP;
//     [SerializeField] private TextMeshProUGUI AT;
//     [SerializeField] private TextMeshProUGUI Difficulty;
//     [SerializeField] private TextMeshProUGUI Name;
//     private Digimon rival;
//
//     private void Start()
//     {
//         rival = GameManager.instance.actualRival.GetComponent<Digimon>();
//         UpdateUI();
//         
//     }
//
//     public void UpdateUI()
//     {
//         rival = GameManager.instance.actualRival.GetComponent<Digimon>();
//         HP.text = rival.HP.ToString();
//         AT.text = rival.AT.ToString();
//         Difficulty.text = rival.rewardEXP.ToString();
//         Name.text = rival.DigimonName;
//         // EXP.text = GameManager.instance.EXP.ToString();
//         // nextLevelEXPUI.text = GameManager.instance.costLevelUp.ToString();
//     }
//
//     public void SetRival(int id)
//     {
//         GameManager.instance.actualRival = GameManager.instance.rival[id];
//     }
//     
// }
