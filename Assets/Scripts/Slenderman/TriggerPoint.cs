using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPoint : MonoBehaviour
{
    [SerializeField] private Transform slenderSpawnPoint;
    [SerializeField] private GameObject slenderman;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player here!");

            // Instantiate slenderman and store the reference
            GameObject instantiatedSlenderman = Instantiate(slenderman, slenderSpawnPoint.position, Quaternion.Euler(0f, 180, 0f));

            // Start coroutines for hiding slenderman and the TriggerPoint GameObject
            StartCoroutine(HideSlender(instantiatedSlenderman));
        }
    }

    private IEnumerator HideSlender(GameObject slendermanToHide)
    {
        yield return new WaitForSeconds(1f);

        slendermanToHide.SetActive(false);

        yield return new WaitForSeconds(1.1f);
        gameObject.SetActive(false);
    }
}
