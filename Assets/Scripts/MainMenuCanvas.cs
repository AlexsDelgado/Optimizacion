using UnityEngine;

public class MainMenuCanvas : MonoBehaviour
{
    [SerializeField] private GameObject playerStatsMenu;
    [SerializeField] private GameObject rivalStatsMenu;
    [SerializeField] private GameObject playerStatsButton;
    [SerializeField] private GameObject rivalStatsButton;
    [SerializeField] private GameObject arenaButton;
    [SerializeField] private GameObject tapirmonButton;
    
    public void OnChangeMenu()
    {
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
     
    private void OpenPlayerStats()
    {
        playerStatsMenu.SetActive(true);
    }
    private void OpenRivalStats()
    {
        rivalStatsMenu.SetActive(true);
    }
    private void ClosePlayerStats()
    {
        playerStatsMenu.SetActive(false);
    }
    private void CloseRivalStats()
    {
        playerStatsMenu.SetActive(false);
    }
    
}
