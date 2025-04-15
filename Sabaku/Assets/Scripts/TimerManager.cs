using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    private float timer;
    private bool isTimerPaused;
    private bool isShopRoom;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isTimerPaused && !isShopRoom && timer >= 0)
        {
            timer -= Time.deltaTime;
        }
        UpdateTimerText();
        
    }

    public void UpdateTimerText()
    {
        Transform timerText = transform.Find("TimerText");
        if (timerText != null)
        {
            if(isShopRoom)
            {
                timerText.GetComponent<TextMeshProUGUI>().text = "-";
            } else 
            {
                timerText.GetComponent<TextMeshProUGUI>().text = timer.ToString("f1");
            }
            
        }
    }

    public float GetTimer()
    {
        return timer;
    }

    public void SetTimer(float newTimer, bool newIsShopRoom)
    {
        timer = newTimer;
        isShopRoom = newIsShopRoom;

    }

    public bool GetIsTimerPaused()
    {
        return isTimerPaused;
    }

    public void SetIsTimerPaused(bool newIsTimerPaused)
    {
        isTimerPaused = newIsTimerPaused;
    }

    public void DeleteSeconds(int number)
    {
        timer -= number;
    }

    public void AddSeconds(int number)
    {
        timer += number;
    }
}
