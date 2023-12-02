using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int pages;
    private InGameMenu menu;


    private void Awake()
    {
        pages = 0;
    }
    private void Start()
    {
        menu = FindObjectOfType<InGameMenu>();
    }

    public void getPages()
    {
        Debug.Log(pages);
        menu.PagesUI();
    }

}
