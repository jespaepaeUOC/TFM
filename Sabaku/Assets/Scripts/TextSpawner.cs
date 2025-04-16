using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class TextSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowPopUpText(String newText = "", float newTextSize = 0.6f, float r = 227f, float g=186f, float b = 102f)
    {
        GameObject gameResources = GameObject.Find("GameResources");
        if(gameResources != null)
        {
            GameObject resource = gameResources.GetComponent<GameResourcesManager>().GetResource(0);
            if(resource != null)
            {
                GameObject popUpText = Instantiate(resource, GameObject.Find("Player").transform.position, Quaternion.identity, transform.parent.transform);
                popUpText.GetComponent<PopUpTextManager>().ChangeText(newText);
                popUpText.GetComponent<PopUpTextManager>().ChangeTextSize(newTextSize);
                popUpText.GetComponent<PopUpTextManager>().ChangeTextColor(r/255f, g/255f, b/255f);
            }
        }
    }
}
