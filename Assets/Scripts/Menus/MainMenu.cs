using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private Animation anim;

    private void Start()
    {
        anim = GetComponentInChildren<Animation>();
        anim.Play();
    }
}
