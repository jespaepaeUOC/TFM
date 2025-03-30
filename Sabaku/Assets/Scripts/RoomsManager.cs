using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnDice()
    {
        GameObject activeRoom = getActiveRoom();
        if (activeRoom != null)
        {
            activeRoom.transform.Find("DiceSpawner").GetComponent<DiceSpawner>().spawnDice();
        }
    }

    private GameObject getActiveRoom()
    {
        GameObject activeRoom = null;
        foreach(Transform room in transform)
        {
            if(room.GetComponent<RoomManager>().isRoomActive())
            {
                activeRoom = room.gameObject;
                break;
            }
        }
        return activeRoom;
    }


}
