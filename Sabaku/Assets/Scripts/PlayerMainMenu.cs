using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y-0.03f, 0);
        if(transform.position.y <= -35)
        {
            transform.position = new Vector3(transform.position.x, -15, 0);
        }
        this.GetComponent<Animator>().SetBool("isFalling", true);
    }
}
