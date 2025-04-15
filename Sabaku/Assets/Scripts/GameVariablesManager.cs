using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameVariablesManager : MonoBehaviour
{
    private int scrolls;
    private int deaths;
    // Start is called before the first frame update
    void Start()
    {
        scrolls = 0;
        deaths = 0;
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

    public void SetScrolls(int scrolls)
    {
        this.scrolls = scrolls;
    }

    public void SetDeaths(int deaths)
    {
        this.deaths = deaths;
    }

    public void AddScroll()
    {
        this.scrolls++;
    }

    public void SpendScroll()
    {
        this.scrolls--;
    }

    public void AddDeath()
    {
        this.deaths++;
    }
}
