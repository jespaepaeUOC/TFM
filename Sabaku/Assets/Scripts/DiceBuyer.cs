using System.Collections;
using System.Collections.Generic;
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

    }

    public void BuyDie(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            GameObject rooms = GameObject.Find("Rooms");
            if(rooms != null)
            {
                rooms.GetComponent<RoomsManager>().AddDieToAllRooms(typeOfDice);
                Destroy(this.gameObject);
                if(die != null)
                {
                    Destroy(die.gameObject);
                }
            }
        }
        
    }

    
}
