using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPlayerDetector : MonoBehaviour
{
    public GameObject ShopText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player") && ShopText != null)
        {
            ShopText.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player") && ShopText != null)
        {
            ShopText.SetActive(false);
        }
    }
}
