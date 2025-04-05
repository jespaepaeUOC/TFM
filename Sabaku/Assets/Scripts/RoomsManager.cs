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
        Debug.Log("RoomsManager - spawnDice");
        GameObject activeRoom = getActiveRoom();
        
        if (activeRoom != null)
        {
            Debug.Log("RoomsManager - spawnDice - beforeSpawnDice");
            activeRoom.transform.Find("DiceSpawner").GetComponent<DiceSpawner>().spawnDice();
        }
    }

    private GameObject getActiveRoom()
    {
        Debug.Log("RoomsManager - getActiveRoom");
        GameObject activeRoom = null;
        foreach(Transform room in transform)
        {
            if(room.GetComponent<RoomManager>().isRoomActive())
            {
                activeRoom = room.gameObject;
                break;
            }
        }
        if (activeRoom != null) Debug.Log("RoomsManager - getActiveRoom - activeRoom: " + activeRoom.name);
        return activeRoom;
    }


}
