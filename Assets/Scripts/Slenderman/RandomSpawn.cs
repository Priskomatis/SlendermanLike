﻿using System.Collections;
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

    private TriggerPoint triggerPoint;

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
        triggerPoint = FindObjectOfType<TriggerPoint>();
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f); // Spawn every Χ seconds

            int randomIndex = GetRandomSpawnPoint();
            if (randomIndex != -1)
            {
                Spawn(spawnPoints[randomIndex].gameObject);
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
        if (!slenderman.activeSelf)
        {
            Debug.Log("Spawning at: " + spawnPoint.name);
            // Add your spawning logic here

            GameObject instantiatedSlenderman = Instantiate(slenderman, spawnPoint.transform.position, Quaternion.Euler(0f, 0f, 0f));
            instantiatedSlenderman.SetActive(true);
            instantiatedSlenderman.transform.LookAt(pc.transform);
            StartCoroutine(triggerPoint.HideSlender(instantiatedSlenderman));
        }
            
    }

}

