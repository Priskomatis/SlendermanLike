using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    /**
     * This script is designed to instantiate slenderman in random places throughout the map;
     * Unlike the TriggerPoint script, slenderman will not disappear once the player sees him,
     * but rather will start "inflicting" damage to the player based on the distance between them;
     * 
     * The only way for slenderman to disappear will be for the player to look away for a number of seconds;
     * 
     * Ideally there will be an invisible radius throughout the player that only the spawnPoints that are inside 
     * that radius will be enabled for the spawn system;
     * 
     * The spawn system should happen every X seconds/minutes that gets decreased based on how many pages you got;
     * In other words, as you progress in the game, Slenderman will start appearing more frequently;
     * 
     */

    [SerializeField] private GameObject[] spawnPoints;

    [SerializeField] private GameObject slenderman;
    [SerializeField] private GameObject pc;

    private PlayerController playerController;

    private TriggerPoint triggerPoint;

    private float spawnTimer = 5f;

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
        triggerPoint = FindObjectOfType<TriggerPoint>();
        playerController = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        Debug.Log(spawnTimer);
        if (playerController.pages < 2)
            spawnTimer = 20f;
        else if (playerController.pages < 4)
            spawnTimer = 15f;
        else if (playerController.pages < 6)
            spawnTimer = 10f;
        else
            spawnTimer = 7f;
    }
    private IEnumerator SpawnRoutine()
    {
        //Debug.Log("Pages: "+playerController.pages);
        while (true)
        {
            yield return new WaitForSeconds(spawnTimer); // Spawn every Χ seconds

            //Here we check if slenderman already exist in our scene, if he does, then we should not spawn another slenderman prefab.
            GameObject slendermanCheck = GameObject.Find("SlenderMan_Prototype(Clone)");
            if (slendermanCheck == null || !slendermanCheck.activeSelf)
            {
                int randomIndex = GetRandomSpawnPoint();
                if (randomIndex != -1)
                {
                    Spawn(spawnPoints[randomIndex].gameObject);
                    Debug.Log(randomIndex);
                }
            }
        }
    }

    private int GetRandomSpawnPoint()
    {
        int x = Random.Range(0, spawnPoints.Length);

        return x;
    }
    private void Spawn(GameObject spawnPoint)
    {
        Debug.Log("Spawning at: " + spawnPoint.name);


        GameObject instantiatedSlenderman = Instantiate(slenderman, spawnPoint.transform.position, Quaternion.Euler(0f, 0f, 0f));
        instantiatedSlenderman.SetActive(true);
        Vector3 currentRotation = instantiatedSlenderman.transform.rotation.eulerAngles;
        instantiatedSlenderman.transform.rotation = Quaternion.Euler(0f, currentRotation.y, currentRotation.z);
        StartCoroutine(triggerPoint.HideSlender(instantiatedSlenderman));

    }

}

