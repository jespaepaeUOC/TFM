using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndGameStatsManager : MonoBehaviour
{
    private GameVariablesManager gameVariables;
    // Start is called before the first frame update
    void Start()
    {
        gameVariables = GameObject.Find("GameVariables").GetComponent<GameVariablesManager>();
        gameVariables.UpdateDeathsHighScore();
        gameVariables.UpdateScrollsHighScore();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateNumberOfScrolls();
        UpdateNumberOfDeaths();
    }

    void UpdateNumberOfScrolls()
    {
        Transform scrolls = this.transform.Find("Background").Find("Scrolls");
        if (scrolls != null && gameVariables != null)
        {
            if(gameVariables.GetScrollsHighScore() == -1)
            {
                scrolls.transform.Find("NumberOf").GetComponentInChildren<TextMeshProUGUI>().text = "-";
            }
            else 
            {
                scrolls.transform.Find("NumberOf").GetComponentInChildren<TextMeshProUGUI>().text = gameVariables.GetScrolls().ToString();
            }
        }
        
    }

    void UpdateNumberOfDeaths()
    {
        Transform deaths = this.transform.Find("Background").Find("Deaths");
        if (deaths != null && gameVariables != null)
        {
            if(gameVariables.GetDeathsHighScore() == 999999999) 
            {
                deaths.transform.Find("NumberOf").GetComponentInChildren<TextMeshProUGUI>().text = "-";
            } 
            else 
            {
                deaths.transform.Find("NumberOf").GetComponentInChildren<TextMeshProUGUI>().text = gameVariables.GetDeaths().ToString();
            }  
        }
    }
}
