using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Flashlight : MonoBehaviour
{
    public Light flashlight;
    public bool isOn;

    private void Start()
    {
        isOn = true;
    }

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
        isOn = !isOn;

    }
    public void TurnOff()
    {
        flashlight.enabled = false;
        isOn = false;
    }
}
