using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadImage : MonoBehaviour
{
    
    [SerializeField] GameObject onLoadImage;
    [SerializeField] GameObject menu;

    private void Start()
    {
        StartCoroutine(HideImage());
    }

    //DO NOT KEEP THIS UNDER ANY CIRCUMSTANCES
    private IEnumerator HideImage()
    {
        yield return new WaitForSeconds(13.2f);
        onLoadImage.SetActive(false);
        menu.SetActive(true);
    }
}
