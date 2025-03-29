using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public GameObject vCam;
    public GameObject diceSpawner;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            vCam.SetActive(true);
            diceSpawner.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            vCam.SetActive(false);
            diceSpawner.SetActive(false);  
        }
    }
}
