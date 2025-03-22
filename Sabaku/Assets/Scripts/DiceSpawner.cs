using System;
using System.Collections;
using System.Collections.Generic;
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

    // Start is called before the first frame update
    void Start()
    {
        eventTrigger = false;
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
                                                                       UnityEngine.Random.Range(transform.position.z, transform.position.z+2)), Quaternion.identity);
                        newDie.GetComponent<Rigidbody>().AddTorque(new Vector3(UnityEngine.Random.Range(-200, 200), UnityEngine.Random.Range(-200, 200), UnityEngine.Random.Range(-200, 200)));
                    }
                }
            }
            eventTrigger = true;
            StartCoroutine(CanSpawn());
        }
    }

    private IEnumerator CanSpawn() {
        yield return new WaitForSeconds(secondsToSpawn);
        eventTrigger = false;
    }
}
