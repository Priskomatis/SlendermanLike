using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PrologueScript : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private int index;
    [SerializeField] GameObject continueBtn;

    public TextMeshProUGUI spaceText;
    [SerializeField] private GameObject spaceTextObject;



    // Start is called before the first frame update
    void Start()
    {
        continueBtn.SetActive(false);
        textComponent.text = string.Empty;
        StartDialogue();
        //continueBtn.interactable = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();

            }
            else

            {
                StopAllCoroutines();
                textComponent.text = lines[index];


            }
        }

    }

    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);

        }
    }

    public void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());

        }
        else
        {
            gameObject.SetActive(false);        //When we have gone through all our senteces, we deactivate our canvas(which contains this dialogue script and UI) and the wizard for visual effects;
            //continueBtn.interactable = true;
            spaceText.enabled = false;
            
            Debug.Log("End of the prologue");
            continueBtn.SetActive(true);
            spaceTextObject.SetActive(false);




        }
    }

    public void EnterGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
