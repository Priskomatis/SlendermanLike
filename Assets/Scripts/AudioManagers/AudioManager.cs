using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource bg_Pages1_2;
    [SerializeField] private AudioSource bg_Pages3_4;
    [SerializeField] private AudioSource bg_Pages5_6;
    [SerializeField] private AudioSource bg_Pages7_8;

    [SerializeField] private PlayerController pc;

    private void Start()
    {
        //pc = FindObjectOfType<PlayerController>();
        bg_Pages1_2.Play();
    }

    public void ChangeAudio(int pages)
    {
        if (pages <= 2)
        {
            return;
        }
        else if(pages == 3 )
        {
            bg_Pages1_2.Stop();
            bg_Pages3_4.Play();
        }
        else if (pages == 5)
        {
            bg_Pages3_4.Stop();
            bg_Pages5_6.Play();
        }
        else if (pages == 7)
        {
            bg_Pages5_6.Stop();
            bg_Pages7_8.Play();
        }
    }
}
