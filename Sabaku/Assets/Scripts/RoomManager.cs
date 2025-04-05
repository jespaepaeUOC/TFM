using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class RoomManager : MonoBehaviour
{
    public GameObject vCam;
    public GameObject diceSpawner;
    public GameObject spikeSpawner;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            vCam.SetActive(true);
            diceSpawner.SetActive(true);
            spikeSpawner.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            Debug.Log("RoomExit");
            vCam.SetActive(false);
            diceSpawner.SetActive(false);
            spikeSpawner.SetActive(false);
            this.transform.parent.GetComponent<RoomsManager>().spawnDice();
        }
    }

    public bool isRoomActive()
    {
        return vCam.activeSelf && diceSpawner.activeSelf && spikeSpawner.activeSelf;
    }
}
