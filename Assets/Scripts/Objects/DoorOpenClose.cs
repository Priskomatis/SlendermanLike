using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenClose : MonoBehaviour
{

    [SerializeField] private Animator anim;
    private bool withinRange;
    private bool doorIsOpen;

    private void Start()
    {
        doorIsOpen = false;
    }
    private void Update()
    {
        //Debug.Log(canOpen);
        if (withinRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!doorIsOpen)
                {
                    anim.SetTrigger("OpenDoor");
                    doorIsOpen = true;


                }
                else
                {
                    anim.SetTrigger("CloseDoor");
                    doorIsOpen= false;
 
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Can Open Door");
            withinRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Can no longer open door");
            withinRange = false;
        }
    }
}
