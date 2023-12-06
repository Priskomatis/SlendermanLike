using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickUpText : MonoBehaviour
{
    [SerializeField] private GameObject pickUpText;
    [SerializeField] private TextMeshProUGUI text;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Page"))
        {
            pickUpText.SetActive(true);
            text.text = "Press 'E' to collect page";

        }
        else if (other.CompareTag("Door"))
        {
            pickUpText.SetActive(true);
            text.text = "Press 'E' to open";
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Page") || other.CompareTag("Door"))
        {
            pickUpText.SetActive(false);
        }
        
    }

}
