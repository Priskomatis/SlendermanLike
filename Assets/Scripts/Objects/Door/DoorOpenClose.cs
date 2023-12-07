using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenClose : MonoBehaviour
{

    [SerializeField] private Animator anim;
    private bool withinRange;
    private bool doorIsOpen;

    [SerializeField] AudioSource audioOpen;

    [SerializeField] AudioSource audioClose;
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
                    StartCoroutine(OpenDoor());
                }
                else
                {
                    StartCoroutine(CloseDoor());
 
                }
            }
        }
    }

    private IEnumerator OpenDoor()
    {
        audioOpen.Play();
        yield return new WaitForSeconds(1f);
        anim.SetTrigger("OpenDoor");
        doorIsOpen = true;
    }

    private IEnumerator CloseDoor()
    {
        audioClose.Play();
        yield return new WaitForSeconds(1f);
        anim.SetTrigger("CloseDoor");
        doorIsOpen = false;
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
