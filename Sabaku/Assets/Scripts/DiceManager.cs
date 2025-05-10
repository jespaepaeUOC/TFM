using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour
{

    public enum typeOfDice{SpawnSpikes, DeleteSpikes, AddSeconds, DeleteSeconds, SpawnEnemies, DeleteEnemies};
    public typeOfDice type;
    private int diceFaceNum; 
    private bool hasntRun;
    // Start is called before the first frame update
    void Start()
    {
        diceFaceNum = 0;
        hasntRun=true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setDiceFaceNum(int num)
    {
        diceFaceNum = num;
        if(hasntRun)
        {
            // Debug.Log("You got a: " + diceFaceNum);
            hasntRun = false;
            makeMagic();
            Destroy(this.gameObject);
        }
        
    }  

    public int getDiceFaceNum()
    {
        return diceFaceNum;
    }

    private void makeMagic()
    {
        SpikeSpawner spikeSpawner = GameObject.Find("SpikeSpawner").GetComponent<SpikeSpawner>();
        EnemySpawner enemySpawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
        TimerManager timerManager = GameObject.Find("Timer").GetComponent<TimerManager>();
        switch(type)
        {
            case typeOfDice.SpawnSpikes:
                spikeSpawner.SpawnSpikes(diceFaceNum);
                break;
            
            case typeOfDice.DeleteSpikes:
                spikeSpawner.DeleteSpikes(diceFaceNum);
                break;

            case typeOfDice.DeleteSeconds:
                timerManager.DeleteSeconds(diceFaceNum);
                break;

            case typeOfDice.AddSeconds:
                timerManager.AddSeconds(diceFaceNum);
                break;

            case typeOfDice.SpawnEnemies:
                enemySpawner.SpawnEnemies(diceFaceNum);
                break;
                
            case typeOfDice.DeleteEnemies:
                enemySpawner.DeleteEnemies(diceFaceNum);
                break;
            
        }
    }
}
