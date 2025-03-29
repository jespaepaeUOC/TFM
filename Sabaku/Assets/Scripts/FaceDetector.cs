using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceDetector : MonoBehaviour
{
    DiceManager die;
    // Start is called before the first frame update
    void Start()
    {
        die = transform.parent.parent.GetComponent<DiceManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if (die != null)
        {
            if (DieHasStopped() && other.CompareTag("DiceFloor"))
            {
                die.gameObject.SetActive(false);
                die.setDiceFaceNum(int.Parse(this.name));
            }
        }
    }

    bool DieHasStopped()
    {
        bool hasStopped = false;

        if (die.GetComponent<Rigidbody>().velocity.magnitude <= 0.01)
        {
            hasStopped = true;
        }

        return hasStopped;
    }
}
