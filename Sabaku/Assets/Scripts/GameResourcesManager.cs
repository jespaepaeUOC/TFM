using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResourcesManager : MonoBehaviour
{
    public List<GameObject> resources;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetResource(int index)
    {
        GameObject resource = null;
        if(resources.Count > index)
        {
            resource = resources[index];
        }

        return resource;
    }
}
