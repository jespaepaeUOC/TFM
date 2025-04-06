using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float amp;
    public float freq;
    Vector3 initPos;
    void Start()
    {
        initPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(initPos.x, Mathf.Sin(Time.time * freq)*amp + initPos.y, 0);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            GameObject.Find("GameVariables").GetComponent<GameVariablesManager>().AddScroll();
            Destroy(this.gameObject);
        }
    }
}
