using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] private Light flashlight;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleLight();
        }
    }
    public void ToggleLight()
    {
        flashlight.enabled = !flashlight.enabled;
    }
}
