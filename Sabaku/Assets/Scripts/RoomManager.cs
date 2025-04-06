using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class RoomManager : MonoBehaviour
{
    public GameObject vCam;
    public GameObject diceSpawner;
    public GameObject spikeSpawner;
    public GameObject respawnPoint;
    public GameObject items;
    private bool isFirstTimeEnteringRoom;

    void Start()
    {
        isFirstTimeEnteringRoom = true;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            vCam.SetActive(true);
            diceSpawner.SetActive(true);
            spikeSpawner.SetActive(true);
            respawnPoint.SetActive(true);
            items.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            Debug.Log("RoomManager - OnTriggerExit2D: Exiting " + this.name);
            vCam.SetActive(false);
            diceSpawner.SetActive(false);
            spikeSpawner.SetActive(false);
            respawnPoint.SetActive(false);
            items.SetActive(false);
            SetIsFirstTimeEnteringRoom(false);
            this.transform.parent.GetComponent<RoomsManager>().spawnDice();
        }
    }

    public bool isRoomActive()
    {
        return vCam.activeSelf && diceSpawner.activeSelf && spikeSpawner.activeSelf && respawnPoint.activeSelf && items.activeSelf;
    }

    public bool GetIsFirstTimeEnteringRoom()
    {
        return isFirstTimeEnteringRoom;
    }

    public void SetIsFirstTimeEnteringRoom(bool NewIsFirstTimeEnteringRoom)
    {
        this.isFirstTimeEnteringRoom = NewIsFirstTimeEnteringRoom;
    }
}
