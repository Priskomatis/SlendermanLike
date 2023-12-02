using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InGameMenu : MonoBehaviour
{
    private PlayerController pc;
    public GameObject menuPanel;

    [SerializeField] private TextMeshProUGUI pagesCount;

    private bool menuOpen;

    private void Start()
    {
        pc = FindObjectOfType<PlayerController>();
        pagesCount.text = 0.ToString();
        menuOpen = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (menuOpen)
            {
                menuPanel.SetActive(false);
                menuOpen = false;
            } else
            {
                menuPanel.SetActive(true);
                menuOpen = true;
            }

        }
    }
    public void PagesUI()
    {
        pagesCount.text = pc.pages.ToString();
    }
}
