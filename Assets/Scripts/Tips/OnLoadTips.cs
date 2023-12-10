using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLoadTips : MonoBehaviour
{
    [SerializeField] private GameObject onLoadPanel;

    private void Start()
    {
        onLoadPanel.SetActive(true);
        StartCoroutine(HideText());

    }

    private IEnumerator HideText()
    {
        yield return new WaitForSeconds(3f);
        onLoadPanel.SetActive(false);
    }
}
