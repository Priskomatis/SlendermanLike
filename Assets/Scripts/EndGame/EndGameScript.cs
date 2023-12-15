using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameScript : MonoBehaviour
{
    [SerializeField] private GameObject text1, text2, text3, btn;

    private void Start()
    {
        StartCoroutine(DisplayText());
    }

    private IEnumerator DisplayText()
    {
        yield return new WaitForSeconds(2f);
        text1.SetActive(true);

        yield return new WaitForSeconds(2f);
        text2.SetActive(true);

        yield return new WaitForSeconds(2f);
        text3.SetActive(true);

        yield return new WaitForSeconds(2f);
        btn.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
