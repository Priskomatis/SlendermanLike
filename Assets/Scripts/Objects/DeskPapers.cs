using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeskPapers : MonoBehaviour
{
    private bool canRead;
    [SerializeField] GameObject notesPanel;
    [SerializeField] string notes;
    [SerializeField] TextMeshProUGUI notesText;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canRead)
        {
            notesPanel.SetActive(true);
            notesText.text = notes;
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
            notesPanel.SetActive(false);
        }
    }

}
