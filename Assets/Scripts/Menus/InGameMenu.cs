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

    //States
    enum States { pause, resume};

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

            //If menu is already open
            if (menuOpen)
            {
                //Unpause the game
                UnPause();

                //Close the menu panel
                menuPanel.SetActive(false);
                menuOpen = false;

                //Disable cursor
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            //if menu is not open
            else
            {
                //Pause the game
                Pause();

                //Activate the menu panel
                menuPanel.SetActive(true);
                menuOpen = true;

                //Enable cursor

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

            }

        }
    }
    public void PagesUI()
    {
        pagesCount.text = pc.pages.ToString();
    }

    public void Resume()
    {
        //Closes game;
        menuPanel.SetActive(false);

        //Stops the game from running
        UnPause();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
    }

    public void UnPause()
    {
        Time.timeScale = 1f;
    }
}
