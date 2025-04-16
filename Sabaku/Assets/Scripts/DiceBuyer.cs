using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class DiceBuyer : MonoBehaviour
{
    public DiceManager.typeOfDice typeOfDice;
    public GameObject die;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ShowPopUpText();
    }

    public void BuyDie(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            GameObject rooms = GameObject.Find("Rooms");
            GameObject textSpawner = GameObject.Find("TextSpawner");
            if(rooms != null && HasEnoughScrolls() && textSpawner != null)
            {
                rooms.GetComponent<RoomsManager>().AddDieToAllRooms(typeOfDice);
                textSpawner.GetComponent<TextSpawner>().ShowPopUpText("-"+DiceCost().ToString()+" scrolls\n", 0.4f);
                SpendScroll();
                Destroy(this.gameObject);
                if(die != null)
                {
                    Destroy(die.gameObject);
                }
            }
        }
    }

    public bool HasEnoughScrolls()
    {
        bool hasEnoughScrolls = false;
        GameObject gameVariables = GameObject.Find("GameVariables");
        if (gameVariables != null)
        {
            if(gameVariables.GetComponent<GameVariablesManager>().GetScrolls() >= DiceCost())
            {
                hasEnoughScrolls = true;
            }
        }
        return hasEnoughScrolls;
    }

    public int DiceCost()
    {
        int diceCost = 999;
        switch(typeOfDice)
        {
            case DiceManager.typeOfDice.AddSeconds:
                diceCost = 1;
                break;

            case DiceManager.typeOfDice.DeleteSpikes:
                diceCost = 2;
                break;

            case DiceManager.typeOfDice.DeleteEnemies:
                diceCost = 3;
                break;
        }
        return diceCost;
    }

    private void SpendScroll()
    {
        GameObject gameVariables = GameObject.Find("GameVariables");
        if (gameVariables != null)
        {
            gameVariables.GetComponent<GameVariablesManager>().SpendScrolls(DiceCost());
        }
    }

    // public void ShowPopUpText(String newText = "", float newTextSize = 0.6f)
    // {
    //     GameObject gameResources = GameObject.Find("GameResources");
    //     if(gameResources != null)
    //     {
    //         GameObject resource = gameResources.GetComponent<GameResourcesManager>().GetResource(0);
    //         if(resource != null)
    //         {
    //             GameObject popUpText = Instantiate(resource, GameObject.Find("Player").transform.position, Quaternion.identity,GameObject.Find("CanvasWorld").transform);
    //             popUpText.GetComponent<PopUpTextManager>().ChangeText(newText);
    //             popUpText.GetComponent<PopUpTextManager>().ChangeTextSize(newTextSize);
    //             popUpText.GetComponent<PopUpTextManager>().ChangeTextColor(227f/255f, 102f/255f, 102f/255f);
    //         }
    //     }
    // }

    // private Vector3 GetPlayerPosition()
    // {
    //     Vector3 playerPosition = GameObject.Find("Player").transform.position;
    //     playerPosition.x -= 961.923f;
    //     playerPosition.y -= 538.896f;
    //     playerPosition.z = 0.0f;
    //     return playerPosition;
    // }

    
}
