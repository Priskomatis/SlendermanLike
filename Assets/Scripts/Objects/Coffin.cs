using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffin : MonoBehaviour
{
    [SerializeField] GameObject coffinCap;
    private bool canOpen;
    [SerializeField] private GameObject page;

    private void Start()
    {
        page.GetComponent<SphereCollider>().enabled = false;

    }
    private void Update()
    {
        if(canOpen && Input.GetKeyDown(KeyCode.E))
        {
            coffinCap.SetActive(false);
            page.GetComponent<SphereCollider>().enabled = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canOpen = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            canOpen = false;
        }
    }
}
