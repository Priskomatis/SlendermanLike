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
            StartCoroutine(DisappearText());

        }
        else if (other.CompareTag("Door"))
        {
            pickUpText.SetActive(true);
            text.text = "Press 'E' to open";
            StartCoroutine(DisappearText());
        }
        else if (other.CompareTag("Battery")){
            pickUpText.SetActive(true);
            text.text = "Press 'E' to pick up Battery";
            StartCoroutine(DisappearText());
        }
        else if (other.CompareTag("Notes"))
        {
            pickUpText.SetActive(true);
            text.text = "Press 'E' to read the notes";
            StartCoroutine(DisappearText());
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Page") || other.CompareTag("Door") || other.CompareTag("Battery"))
        {
            pickUpText.SetActive(false);
        }
        
    }

    private IEnumerator DisappearText()
    {
        yield return new WaitForSeconds(3f);
        pickUpText.SetActive(false);
    }

}
