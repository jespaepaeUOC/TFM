using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    GameObject snailResource;
    GameObject allEnemies;
    public List<Vector3> posibleSnailPositions;
    public List<int> SnailPositionLimits;

    private int greenDiceNumber;
    // Start is called before the first frame update
    void Start()
    {
        greenDiceNumber = 0;
        GameObject gameResources = GameObject.Find("GameResources");
        allEnemies = GameObject.Find("AllEnemies");
        if(gameResources != null)
        {
            snailResource = gameResources.GetComponent<GameResourcesManager>().GetResource(1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGreenDiceNumber(int newGreenDiceNumber)
    {
        greenDiceNumber = newGreenDiceNumber;
    }

    public void DeleteAllEnemies()
    {
        if(allEnemies != null)
        {
            foreach(Transform snail in allEnemies.transform)
            {
                Destroy(snail.gameObject);
            }
        }
        
    }

    public void SpawnEnemies(int number)
    {
        Debug.Log("DiceNumber (Red): " + number);
        for(int i = 0; i < number; i++)
        {
            if(greenDiceNumber > 0)
            {
                greenDiceNumber--;
                continue;
            }
            if(posibleSnailPositions.Count > 0 && SnailPositionLimits.Count > 0)
            {
                int randomSnail = Random.Range(0, posibleSnailPositions.Count);
                float randomSnailSpeed = Random.Range(0.5f, 1.5f);
                Vector3 position = posibleSnailPositions[randomSnail];
                int randomSnailLimit = SnailPositionLimits[randomSnail];
                if(snailResource != null)
                {
                    GameObject snail = Instantiate(snailResource, position, Quaternion.identity, GameObject.Find("AllEnemies").transform);
                    SnailManager snailManager = snail.transform.Find("Snail").GetComponent<SnailManager>();
                    snailManager.speed = randomSnailSpeed;
                    snailManager.limit = randomSnailLimit;
                }
            }
        }
    }

    public void DeleteEnemies(int number)
    {
        int numberOfSnails = CountAllEnemies();
        Debug.Log("DiceNumber (Green): " + number);
        Debug.Log("NumberOfEnemies: " + numberOfSnails);
        if(number > numberOfSnails) 
        {
            greenDiceNumber += number - numberOfSnails;
        }
        Debug.Log("greenDiceNumber: " + greenDiceNumber);
        for(int i = 0; i < number; i++)
        {
            if (i < CountAllEnemies()) {
                Destroy(allEnemies.transform.GetChild(i).gameObject);
            }
        }
    }

    private int CountAllEnemies()
    {
        int count = 0;
        if(allEnemies != null)
        {
            foreach(Transform snail in allEnemies.transform)
            {
                count++;
            }
        }
        return count;
    }
}
