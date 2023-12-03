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

    private void OnTriggerEnter(Collider other)
    {
        // If the player steps inside the trigger area that we set;
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player here!");

            // Instantiate slenderman and store the reference
            GameObject instantiatedSlenderman = Instantiate(slenderman, slenderSpawnPoint.position, Quaternion.Euler(0f, 180, 0f));

            // Start coroutines for hiding slenderman and the TriggerPoint GameObject;
            //This makes to so we disable the slenderman game object after fixed amount of time has passed;
            StartCoroutine(HideSlender(instantiatedSlenderman));
        }
    }

    private IEnumerator HideSlender(GameObject slendermanToHide)
    {
        // Wait 1f seconds before continuing;
        yield return new WaitForSeconds(1f);
        
        //Call the function to check when to disable slenderman prefab;
        if(IsVisible(camera, slendermanToHide))
        {
            slendermanToHide.SetActive(false);
        }
        
        yield return new WaitForSeconds(1.1f);
        gameObject.SetActive(false);
    }

    // Function to check if slenderman is visible in the camera view
    private bool IsVisible(Camera c, GameObject target)
    {
        //Calculates frustum planes by taking the camer's views and returns 6 planes that form it;
        var planes = GeometryUtility.CalculateFrustumPlanes(c);
        var point = target.transform.position;

        foreach(var plane in planes)
        {
            if(plane.GetDistanceToPoint(point) > 0)
            {
                return false;
            }
        }
        return true;
    }


}
