using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class DialogueManager : MonoBehaviour
{
    private Queue<Dialogue> dialogues;
    public TextMeshProUGUI dialogueText;
    public Image dialogueCharacterImage;

    public Animator animator;
    private PlayerController playerC;
    [Space]
    public float timeBetweenLetters = 0.01f;
    [Space]
    public GameObject hotbarCanvasUI;

    public UnityAction dialogueEnd;
    private bool typingClicked;
    private bool doneTyping;

    private bool inDialogue = false;
    void Start()
    {
        dialogues = new Queue<Dialogue>();
        playerC = FindObjectOfType<PlayerController>();

    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && inDialogue)
        {

            if (doneTyping)
            {
                DisplayNextMessage();
            }
            else
            {
                typingClicked = true;
            }
            
        }
    }

    public void StartDialogue(Dialogue[] dialoguez)
    {
        inDialogue = true;
        
        playerC.SetLockMovement(true);
        if (hotbarCanvasUI != null)
        {
            hotbarCanvasUI.SetActive(false);
        }
        animator.SetBool("IsOpen", true);

        dialogues.Clear();

        foreach (Dialogue d in dialoguez)
        {
            dialogues.Enqueue(d);
        }

        DisplayNextMessage();
    }
    public void DisplayNextMessage()
    {
        doneTyping = false;
        
        if (dialogues.Count == 0)
        {
            EndDialogue();
            return;
        }

        Dialogue dialogue = dialogues.Dequeue();


        //dialogueText.text = dialogue.sentence;
        StopAllCoroutines();
        StartCoroutine(TypeDialogue(dialogue.sentence));

        dialogueCharacterImage.sprite = dialogue.picture;

        if (dialogue.picture == null) //Se till att bilden f�rsvinner om det inte �r n�gon
        {
            dialogueCharacterImage.gameObject.SetActive(false);
        }
        else
        {
            dialogueCharacterImage.gameObject.SetActive(true);
        }
    }

    IEnumerator TypeDialogue (string sentence)
    {
        dialogueText.text = " ";
        foreach  (char letter in sentence.ToCharArray())
        {

            if (typingClicked)
            {
                typingClicked = false;
                dialogueText.text = sentence;
                break;
            }
            dialogueText.text += letter;
            yield return new WaitForSeconds(timeBetweenLetters);
            
            //yield return null; //kommer skriva en bokstav per frame
        }

        doneTyping = true;
        typingClicked = false;
    }

    void EndDialogue()
    {
        inDialogue = false;
        StopAllCoroutines();
        StartCoroutine(UnlockMovementDelay()); //titta ner
        if (hotbarCanvasUI != null)
        {
            hotbarCanvasUI.SetActive(true);

        }
        animator.SetBool("IsOpen", false);

        dialogueEnd?.Invoke();
    }

    IEnumerator UnlockMovementDelay() //v�ntar till slutet av framen f�r att f�rhindra att gubben sl�r
    {                                 //d� dessa olika updates kan komma otajmat  
        yield return new WaitForEndOfFrame();
        playerC.SetLockMovement(false);
    }

}
