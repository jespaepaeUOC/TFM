using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour
{

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
            SpikeSpawner spikeSpawner = GameObject.Find("SpikeSpawner").GetComponent<SpikeSpawner>();
            spikeSpawner.SpawnSpikes(diceFaceNum);
            Destroy(this.gameObject);
        }
        
    }  

    public int getDiceFaceNum()
    {
        return diceFaceNum;
    }
}
