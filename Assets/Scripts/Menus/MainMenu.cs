using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] AudioSource clip;


    [SerializeField] GameObject options;
    [SerializeField] GameObject menuUI;


    private void Start()
    {
        slider.minValue = 0;

        slider.onValueChanged.AddListener(ChangeVolume);
    }
    private void Awake()
    {
        DontDestroyOnLoad(slider);
    }



    void ChangeVolume(float volume)
    {
        // Set the volume of the audio source based on the slider value
        clip.volume = volume;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Prologue");
    }
    public void Options()
    {
        menuUI.SetActive(false);
        options.SetActive(true);
    }
    public void BackToMenu()
    {
        options.SetActive(false);
        menuUI.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
