using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
     [SerializeField] private Animation anim;
     [SerializeField] private Animation anim2;

    private void Start()
    {
        anim = GetComponentInChildren<Animation>();
        anim.Play();
        
    }
}
