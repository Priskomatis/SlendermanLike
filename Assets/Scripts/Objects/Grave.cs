using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Grave : MonoBehaviour
{
    [SerializeField] private GameObject gravePanel;
    private bool canRead;
    [SerializeField] private string text;
    [SerializeField] private TextMeshProUGUI textPlace;



    private void Update()
    {
        if (canRead && Input.GetKeyDown(KeyCode.E)){
            textPlace.text = text;
            gravePanel.SetActive(true);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canRead = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canRead = false;
            gravePanel.SetActive(false);

        }
    }
}
