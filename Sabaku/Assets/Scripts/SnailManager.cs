using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailManager : MonoBehaviour
{
    public float speed;
    public float limit;
    private bool goLeft = true;
    private bool isFalling = false;
    private bool hasFlipped = false;
    // Start is called before the first frame update
    void Start()
    {
        goLeft = true;
        if (limit == 0f)
        {
            limit = 1f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!isFalling)
        {
            if(goLeft)
            {
                GoLeft();
            } else 
            {
                GoRight();
            }

            CheckLimits();
        } 
        else 
        {
            GoDown();
        }
    }

    private void GoRight()
    {
        transform.position = new Vector3(transform.position.x + Time.deltaTime*speed,transform.position.y,transform.position.z);
    }

    private void GoLeft()
    {
        transform.position = new Vector3(transform.position.x - Time.deltaTime*speed,transform.position.y,transform.position.z);
    }

    private void GoDown()
    {
        speed += Time.deltaTime*9.8f;
        transform.position = new Vector3(transform.position.x,transform.position.y - Time.deltaTime*speed,transform.position.z);
        StartCoroutine(DestroyAfterSeconds());
    }

    private void CheckLimits()
    {
        if(transform.localPosition.x <= -limit)
        {
            Flip();
            goLeft = false;
        } else if (transform.localPosition.x >= limit)
        {
            Flip();
            goLeft = true;
        }
    }

    private void Flip()
    {
        if(!hasFlipped)
        {
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
            hasFlipped = true;
            StartCoroutine(CanFlipAfterSeconds());
        }
        
    }

    private IEnumerator CanFlipAfterSeconds() {
        yield return new WaitForSeconds(0.2f);
        hasFlipped = false;
    }

    public void Fall()
    {
        isFalling = true;
    }

    private IEnumerator DestroyAfterSeconds() {
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }


}
