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


    private void OnTriggerEnter(Collider other)
    {
        // If the player steps inside the trigger area that we set;
        if (!hasSpawned && other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player here!");

            // Instantiate slenderman and store the reference
            GameObject instantiatedSlenderman = Instantiate(slenderman, slenderSpawnPoint.position, Quaternion.Euler(0f, 180, 0f));

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
        slendermanToHide.SetActive(false);
        
    }

    private bool IsPlayerLookingAt(GameObject target)
    {
        RaycastHit hit;
        if(Physics.Raycast(camera.transform.position, camera.transform.forward, out hit))
        {
            if (hit.collider.gameObject == target)
            {
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
