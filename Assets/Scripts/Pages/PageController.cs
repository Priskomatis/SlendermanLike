using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PageController : MonoBehaviour
{
    private bool collectable = false;

    [SerializeField] private PlayerController pc;


    [SerializeField] private GameObject pagePanel;
    [SerializeField] private TextMeshProUGUI pageText;

    [SerializeField] private MeshRenderer graphics;

    [SerializeField] private AudioSource audioSource;
    private AudioManager audioManager;

    private SpeechController speechController;

    [SerializeField] private TextMeshProUGUI pageNumber;
    //Text for when you pick up a page;

    [SerializeField] private string textPagePickUp;


    private void Start()
    {
        //pc = FindObjectOfType<PlayerController>();
        audioManager = FindObjectOfType<AudioManager>();
        speechController = FindObjectOfType<SpeechController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && collectable)
        {
            Debug.Log("Collect page: "+gameObject.name);

            audioSource.Play();

            pc.pages += 1;
            pc.getPages();

            //Check to see what text will appear based on how many pages the player got;
            if(pc.pages == 1)
            {
                textPagePickUp = "What? What is this page?";
            }
            else if(pc.pages == 2)
            {
                textPagePickUp = "What the hell kind of joke is this";
            }
            else if (pc.pages == 3)
            {
                textPagePickUp = "WHY ARE YOU DOING THIS?";
            }
            else if (pc.pages == 4)
            {
                textPagePickUp = "This gotta end...";
            }
            else if (pc.pages ==5)
            {
                textPagePickUp = "Oh god help me...";
            }
            else if (pc.pages == 6)
            {
                textPagePickUp = "How many more are there?";
            }
            else if (pc.pages == 7)
            {
                textPagePickUp = "I want this nightmare to be over..";
            }
            else if (pc.pages == 8)
            {
                textPagePickUp = "Please leave me alone";
            }


            StartCoroutine(speechController.SetText(textPagePickUp));

            audioManager.ChangeAudio(pc.pages);

            graphics.enabled = false;

            //UI Activation;
            pagePanel.SetActive(true);
            pageText.text = (pc.pages.ToString()+"/8");

            pageNumber.text = (pc.pages).ToString();
            


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
