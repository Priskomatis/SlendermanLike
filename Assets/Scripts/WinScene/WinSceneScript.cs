using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinSceneScript : MonoBehaviour
{

    [SerializeField] GameObject slenderImg, text1, text2, btn;

    private void Start()
    {
        StartCoroutine(HideSlender());
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
    private IEnumerator HideSlender()
    {
        yield return new WaitForSeconds(2f);
        slenderImg.SetActive(false);

        text1.SetActive(true);

        yield return new WaitForSeconds(2f);
        text2.SetActive(true);

        yield return new WaitForSeconds(2f);
        btn.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
