using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoundPlayer : MonoBehaviour
{
    /** This script is responsibility for the functionality of Slenderman when encountering the player from 3 different ranges;
     * 
     * Ranges: Close/Medium/Far
     * 
     * Close:
     * Medium:
     * Far:
     * 
     * Slenderman detects how far the player is based on the distance between them
     * 
     * 
     */

    public Transform playerTransform;
    public float shortRange = 10f;
    public float medRange = 30f;
    public float longRange = 50f;

    private void Update()
    {
        // Calculate the distance between Slenderman and the player
        float distanceToPlayer = (transform.position - playerTransform.position).sqrMagnitude;

        // We check if the player is close enough to Slenderman


        if (distanceToPlayer <= shortRange)
        {
            ShortRange();
        }
        else if (distanceToPlayer <= medRange)
        {
            MedRange();
        }
        else if (distanceToPlayer <= longRange)
        {
            LongRange();
        }
        else OutOfRange();
    }

    void ShortRange()
    {
        //Debug.Log("Player is in close range");
    }
    void MedRange()
    {
        //Debug.Log("Player is in medium range");
    }
    void LongRange()
    {
        //Debug.Log("Player is in long range");
    }

    void OutOfRange()
    {
        //Debug.Log("Player is nowhere to be seen");
    }
}
