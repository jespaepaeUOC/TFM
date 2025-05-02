using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainMenuScene")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y-0.01f, 0);
            if(transform.position.y <= -35)
            {
                transform.position = new Vector3(transform.position.x, -15, 0);
            }
            this.GetComponent<Animator>().SetBool("isFalling", true);
        }
        else 
        {
            this.GetComponent<Animator>().SetBool("isRunning", false);
            this.GetComponent<Animator>().SetBool("isJumping", false);
            this.GetComponent<Animator>().SetBool("isFalling", false);
            this.GetComponent<Animator>().SetBool("isInverting", false);
        }
        
    }
}
