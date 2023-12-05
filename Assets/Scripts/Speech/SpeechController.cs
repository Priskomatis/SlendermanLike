using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpeechController : MonoBehaviour
{
    [SerializeField] private string text1;
    [SerializeField] private GameObject textPanel;
    [SerializeField] private TextMeshProUGUI textPlaceHolder;

    

    //Function to generate a text
    public IEnumerator SetText()
    {

        textPanel.SetActive(true);
        textPlaceHolder.text = text1;

        yield return new WaitForSeconds(2f);
        textPanel.SetActive(false);
    }
}
