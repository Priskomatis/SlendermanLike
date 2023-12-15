using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BatteryScript : MonoBehaviour
{
 /**
 * Battery is script is used to charge up your flashlight throughout the game;
 * You find and collect batteries throughout the game to avoid your flashlight turning off;
 */
    private Flashlight flashLight;
    [SerializeField] private Slider slider;
    private bool pickUp;

    private float energyConsumptionRate = 0.3f;

    private void Start()
    {
        flashLight = FindObjectOfType<Flashlight>();

        slider.minValue = 0;
        slider.maxValue = 100;

        slider.value = 100;
    }

    private void Update()
    {
        if (flashLight.isOn)
        {
            // Only consume energy when the flashlight is on;
            ConsumeEnergy();
        }

        if (pickUp && Input.GetKeyDown(KeyCode.E))
        {
            RechargeBattery();
            gameObject.SetActive(false);
        }
        if (slider.value == 0)
        {
            flashLight.TurnOff();
        }
    }

    private void ConsumeEnergy()
    {
        slider.value -= energyConsumptionRate * Time.deltaTime; //The slider decreaess based on how much energy we have consumed;

    }

    public void RechargeBattery()
    {
        // Recharge the battery by a fixed amount;
        slider.value += 30;

        if (slider.value > 100)
        {
            slider.value = 100;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pickUp = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        pickUp = false;
    }
}
