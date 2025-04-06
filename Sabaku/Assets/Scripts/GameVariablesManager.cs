using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameVariablesManager : MonoBehaviour
{
    private int scrolls;
    // Start is called before the first frame update
    void Start()
    {
        scrolls = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetScrolls()
    {
        return scrolls;
    }

    public void SetScrolls(int scrolls)
    {
        this.scrolls = scrolls;
    }

    public void AddScroll()
    {
        this.scrolls++;
    }
}
