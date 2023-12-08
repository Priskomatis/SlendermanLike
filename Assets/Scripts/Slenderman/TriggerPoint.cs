using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPoint : MonoBehaviour
{

    /**
     * 
     * TriggerPoint class is a script for the sole purpose of the generation of "Jump Scare" event system;
     * Basic methodology:
     * Once the player enters a trigger area, the Slenderman prefab game object will be instantiated in a spawn point location;
     * This script takes the following parameters:
     * -Transform slenderSpawnPoint: The location where the prefab Slenderman game object will be instantiated in the game world;
     * -Camera camera: The main camera of the game, this should located on the player game object;
     * -GameObject slenderman: The prefab gameObject of the Slenderman that gets instantiated;
     * 
     */
    [SerializeField] private Camera camera;

    [SerializeField] private Transform slenderSpawnPoint;
    [SerializeField] private GameObject slenderman;

    private bool hasSpawned = false;

    [SerializeField] private AudioSource jumpScare;
    [SerializeField] private AudioSource heartBeat;

    private Flashlight flashLight;
    [SerializeField] Light light;
    public enum Direction
    {
        North,
        East,
        West,
        South
    }

    [Header("Direction List")]
    public Direction[] directions;

    private float currentDirection;

    private void Start()
    {

        flashLight = FindObjectOfType<Flashlight>();

        //We do this to find out the correct position of slender's rotation, so that we can play him looking at the player;
        if(directions[0].ToString() == "North")
        {
            currentDirection = 0f;
        }
        else if (directions[0].ToString() == "South")
        {
            currentDirection = 90f;
        }
        else if (directions[0].ToString() == "West")
        {
            currentDirection = 180f;
        }
        else
        {
            currentDirection = 270f;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        // If the player steps inside the trigger area that we set;
        if (!hasSpawned && other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player here!");

            // Instantiate slenderman and store the reference
            GameObject instantiatedSlenderman = Instantiate(slenderman, slenderSpawnPoint.position, Quaternion.Euler(0f, currentDirection, 0f));

            // Start coroutines for hiding slenderman and the TriggerPoint GameObject;
            //This makes to so we disable the slenderman game object after fixed amount of time has passed;
            StartCoroutine(HideSlender(instantiatedSlenderman));
            hasSpawned = true;
        }
    }

    private IEnumerator HideSlender(GameObject slendermanToHide)
    {
        while (!IsPlayerLookingAt(slendermanToHide))
        {
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(0.1f);

        slendermanToHide.SetActive(false);
        heartBeat.Play();
        //Test - turn off the flashlight and the light
        flashLight.ToggleLight();
        if (light != null)
        {
            light.enabled = false;
            yield return new WaitForSeconds(0.2f);
            light.enabled = true;
            yield return new WaitForSeconds(0.2f);
            light.enabled = false;
            yield return new WaitForSeconds(0.2f);
            light.enabled = true;
            yield return new WaitForSeconds(0.2f);
            light.enabled = false;

        }
        


    }



    private bool IsPlayerLookingAt(GameObject target)
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit))
        {

            if (hit.collider.gameObject == target)
            {
                jumpScare.Play();
                Debug.Log("Found slender");


                return true;
            }
        }
        else
        {
            Debug.Log("Nowhere to be seen.");
        }
        return false;
    }






}
