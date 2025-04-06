using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class DiceSpawner : MonoBehaviour
{
    [SerializeField]
    List<GameObject> dice;
    [SerializeField]
    List<int> diceQuantity;
    [SerializeField]
    float secondsToSpawn;
    [SerializeField]
    int offset;
    bool eventTrigger;
    private float originalGravity = 4;
    private Vector3 originalVelocity;
    private bool hasPaused;

    // Start is called before the first frame update
    void Start()
    {
        eventTrigger = false;
        hasPaused = false;
    }

    void Update()
    {
        if(ThereAreDice())
        {
            PausePlayer();
        } 
        else
        {
            UnpausePlayer();
        }
    }

    public void spawnDice(InputAction.CallbackContext context) {
        if(diceQuantity.Count > 0 && !eventTrigger) {
            foreach (GameObject die in dice) {
                int index = dice.IndexOf(die);
                if (index < diceQuantity.Count)
                {
                    for (int i = 0; i < diceQuantity[index]; i++)
                    {
                        GameObject newDie = Instantiate(die, new Vector3(UnityEngine.Random.Range(transform.position.x-offset, transform.position.x+offset), 
                                                                       UnityEngine.Random.Range(transform.position.y-offset, transform.position.y+offset), 
                                                                       UnityEngine.Random.Range(transform.position.z, transform.position.z+2)), Quaternion.identity, GameObject.Find("AllDice").transform);
                        newDie.GetComponent<Rigidbody>().AddTorque(new Vector3(UnityEngine.Random.Range(-200, 200), UnityEngine.Random.Range(-200, 200), UnityEngine.Random.Range(-200, 200)));
                    }
                }
            }
            eventTrigger = true;
            StartCoroutine(CanSpawnAfterSeconds());
        }
    }

    public void spawnDice() {
        if(diceQuantity.Count > 0 && !eventTrigger && CanSpawn()) {
            BeforeEachDiceRoll();
            foreach (GameObject die in dice) {
                int index = dice.IndexOf(die);
                if (index < diceQuantity.Count)
                {
                    for (int i = 0; i < diceQuantity[index]; i++)
                    {
                        GameObject newDie = Instantiate(die, new Vector3(UnityEngine.Random.Range(transform.position.x-offset, transform.position.x+offset), 
                                                                       UnityEngine.Random.Range(transform.position.y-offset, transform.position.y+offset), 
                                                                       UnityEngine.Random.Range(transform.position.z, transform.position.z+2)), Quaternion.identity, GameObject.Find("AllDice").transform);
                        newDie.GetComponent<Rigidbody>().AddTorque(new Vector3(UnityEngine.Random.Range(-200, 200), UnityEngine.Random.Range(-200, 200), UnityEngine.Random.Range(-200, 200)));
                    }
                }
            }
            eventTrigger = true;
            StartCoroutine(CanSpawnAfterSeconds());
        }
    }

    private void BeforeEachDiceRoll()
    {
        SpikeSpawner spikeSpawner = transform.parent.transform.Find("SpikeSpawner").GetComponent<SpikeSpawner>();
        if (spikeSpawner != null)
        {
            spikeSpawner.SetPurpleDiceNumber(0);
        }
    }

    private IEnumerator CanSpawnAfterSeconds() {
        yield return new WaitForSeconds(secondsToSpawn);
        eventTrigger = false;
    }

    private bool ThereAreDice()
    {
        bool thereAreDice = false;

        if(GameObject.Find("AllDice").transform.childCount > 0)
        {
            thereAreDice = true;
        }

        return thereAreDice;
    }

    private void PausePlayer()
    {
        GameObject player = GameObject.Find("Player");
        if(player != null && !hasPaused)
        {
            player.GetComponent<Animator>().enabled = false;
            player.GetComponent<PlayerInput>().enabled = false;
            player.GetComponent<PlayerMovement>().enabled = false;
            Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
            originalVelocity = rb.velocity;
            rb.velocity = Vector3.zero;
            // originalGravity = rb.gravityScale;
            rb.gravityScale = 0f;
            hasPaused = true;
        }
    }

    private void UnpausePlayer()
    {
        GameObject player = GameObject.Find("Player");
        if(player != null && hasPaused)
        {
            player.GetComponent<Animator>().enabled = true;
            player.GetComponent<PlayerInput>().enabled = true;
            player.GetComponent<PlayerMovement>().enabled = true;
            Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
            rb.gravityScale = originalGravity;
            rb.velocity = originalVelocity;
            hasPaused = false;
        }
    }

    private bool CanSpawn()
    {
        bool canSpawn = true;
        RoomManager roomManager = transform.parent.GetComponent<RoomManager>();
        PlayerMovement player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        if (roomManager != null && player != null)
        {
            canSpawn = roomManager.GetIsFirstTimeEnteringRoom() || player.GetHasJustDied();
            player.SetHasJustDied(false);
        }
        return canSpawn;
    }
}
