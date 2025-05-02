using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameVariablesManager : MonoBehaviour
{
    public int scrolls;
    public int deaths;
    public int scrollsHighScore;
    public int deathsHighScore;
    // Start is called before the first frame update
    void Start()
    {
        GameVariables gameVariables = SaveVariablesManager.LoadVariables();
        scrolls = 0;
        deaths = 0;
        scrollsHighScore = gameVariables.scrollsHighScore;
        deathsHighScore = gameVariables.deathsHighScore;
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetScrolls()
    {
        return scrolls;
    }

    public int GetDeaths()
    {
        return deaths;
    }

    public int GetScrollsHighScore()
    {
        return scrollsHighScore;
    }

    public int GetDeathsHighScore()
    {
        return deathsHighScore;
    }

    public void SetScrolls(int scrolls)
    {
        this.scrolls = scrolls;
    }

    public void SetDeaths(int deaths)
    {
        this.deaths = deaths;
    }

    public void SetScrollsHighScore(int scrollsHighScore)
    {
        this.scrollsHighScore = scrollsHighScore;
    }

    public void SetDeathsHighScore(int deathsHighScore)
    {
        this.deathsHighScore = deathsHighScore;
    }

    public void AddScroll()
    {
        this.scrolls++;
    }

    public void SpendScrolls(int numberOfScrollsSpent)
    {
        this.scrolls -= numberOfScrollsSpent;
    }

    public void AddDeath()
    {
        this.deaths++;
    }

    public void UpdateDeathsHighScore()
    {
        if(this.deathsHighScore > this.deaths)
        {
            this.deathsHighScore = this.deaths;
        }
    }

    public void UpdateScrollsHighScore()
    {
        if(this.scrollsHighScore < this.scrolls)
        {
            this.scrollsHighScore = this.scrolls;
        }
    }

    void OnApplicationQuit()
    {
        GameVariables newGameVariables = new GameVariables
        {
            scrolls = this.scrolls,
            deaths = this.deaths,
            scrollsHighScore = this.scrollsHighScore,
            deathsHighScore = this.deathsHighScore
        };

        SaveVariablesManager.SaveVariables(newGameVariables);
    }
}
