using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PageController : MonoBehaviour
{
    private bool collectable = false;

    private PlayerController pc;


    [SerializeField] private GameObject pagePanel;
    [SerializeField] private TextMeshProUGUI pageText;

    [SerializeField] private MeshRenderer graphics;

    [SerializeField] private AudioSource audioSource;

    private void Start()
    {
        pc = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && collectable)
        {
            Debug.Log("Collect page: "+gameObject.name);

            audioSource.Play();

            pc.pages += 1;
            pc.getPages();

            graphics.enabled = false;

            //UI Activation;
            pagePanel.SetActive(true);
            pageText.text = (pc.pages.ToString()+"/8");


            StartCoroutine(PageDisappear());           
            StartCoroutine(ObjectDisappear());

            
        }
    }

    //Page text should disappear after 3 seconds;

    private IEnumerator PageDisappear()
    {
        yield return new WaitForSeconds(3f); 
        pagePanel.SetActive(false);
    }
    private IEnumerator ObjectDisappear()
    {
        yield return StartCoroutine(PageDisappear());

        // Deactivate the entire GameObject
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Collect page");
            collectable = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        collectable = false;
    }
}
