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

    [SerializeField] Transform pc;

    private bool hasSpawned = false;

    [SerializeField] private AudioSource jumpScare;
    [SerializeField] private AudioSource heartBeat;

    private Flashlight flashLight;
    [SerializeField] Light light;

    private CameraShake cameraShake;
    //Foudn a better way to do this with transform.LookAt();
    /**public enum Direction
    {
        North,
        East,
        West,
        South
    //

    [Header("Direction List")]
    public Direction[] directions;*/


    private void Start()
    {
        cameraShake = FindObjectOfType<CameraShake>();
        flashLight = FindObjectOfType<Flashlight>();
    }


    private void OnTriggerEnter(Collider other)
    {
        // If the player steps inside the trigger area that we set;
        if (!hasSpawned && other.gameObject.CompareTag("Player"))
        {
            // Debug.Log("Player here!");

            // Instantiate slenderman and store the reference
            GameObject instantiatedSlenderman = Instantiate(slenderman, slenderSpawnPoint.position, Quaternion.Euler(0f, 0f, 0f));
            instantiatedSlenderman.SetActive(true);
            instantiatedSlenderman.transform.LookAt(pc);
            // Start coroutines for hiding slenderman and the TriggerPoint GameObject;
            //This makes to so we disable the slenderman game object after fixed amount of time has passed;
            StartCoroutine(DisappearSlender());
            StartCoroutine(HideSlender(instantiatedSlenderman));
            hasSpawned = true;
        }
    }

    public IEnumerator HideSlender(GameObject slendermanToHide)
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
        cameraShake.shakeDuration = 0.7f;


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

    private IEnumerator DisappearSlender()
    {
        yield return new WaitForSeconds(5f);
        slenderman.SetActive(false);
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