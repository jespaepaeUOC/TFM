using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameVariablesManager gameVariables;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateNumberOfScrolls();
    }

    void UpdateNumberOfScrolls()
    {
        Transform scrollInventory = this.transform.Find("ScrollInventory");
        if (scrollInventory != null)
        {
            scrollInventory.transform.Find("NumberOf").GetComponentInChildren<TextMeshProUGUI>().text = gameVariables.GetScrolls().ToString();
        }
        
    }
}
