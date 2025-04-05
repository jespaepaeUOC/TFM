using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour
{

    public enum typeOfDice{SpawnSpikes, DeleteSpikes, AddSecond, DeleteSeconds, SpawnEnemies, DeleteEnemies};
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
        switch(type)
        {
            case typeOfDice.SpawnSpikes:
                spikeSpawner.SpawnSpikes(diceFaceNum);
                break;
            
            case typeOfDice.DeleteSpikes:
                spikeSpawner.DeleteSpikes(diceFaceNum);
                break;
            
        }
    }
}
