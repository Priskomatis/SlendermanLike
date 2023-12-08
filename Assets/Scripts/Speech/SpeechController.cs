using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpeechController : MonoBehaviour
{
    //[SerializeField] private string randomThoughts;
    [SerializeField] private GameObject textPanel;
    [SerializeField] private TextMeshProUGUI textPlaceHolder;

    PageController pageController;


    //Function to generate a text
    public IEnumerator SetText(string text)
    {

        textPanel.SetActive(true);
        textPlaceHolder.text = text;

        yield return new WaitForSeconds(2f);
        textPanel.SetActive(false);
    }
}
