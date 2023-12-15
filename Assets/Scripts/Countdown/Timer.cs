using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    /*
     * This is a temporary script that might make it to full release depending on feedback receive;
     * The purpose of this script is to create a challenge to the game and make a losing scenario for the player;
     * If the countdown reaches 0, then slenderman wins, and the player falls in "parania";
     */

    private float countdownTime = 600; // Initial time in seconds is 10 minutes;
    [SerializeField] private TextMeshProUGUI countdownText;

    void Start()
    {
        
        UpdateCountdownText();
        InvokeRepeating("UpdateTimer", 1f, 1f); // Invoke UpdateTimer every 1 second for the countdown;
    }

    void UpdateTimer()
    {
        if (countdownTime > 0)
        {
            countdownTime -= 1f;
            UpdateCountdownText();
        }
        else
        {
            countdownTime = 0;
            //Lose Game Scenario
            Debug.Log("Countdown Reached Zero");
            LoseGame();
        }
    }

    //Conversion from seconds to the format we want to display on screen;
    void UpdateCountdownText()
    {
        int minutes = Mathf.FloorToInt(countdownTime / 60);
        int seconds = Mathf.FloorToInt(countdownTime % 60);
        countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void LoseGame()
    {
        SceneManager.LoadScene("EndGame");
    }
}
