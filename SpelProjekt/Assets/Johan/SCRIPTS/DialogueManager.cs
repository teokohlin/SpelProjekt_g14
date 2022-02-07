using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    private Queue<Dialogue> dialogues;
    public TextMeshProUGUI dialogueText;
    public Image dialogueCharacterImage;

    public Animator animator;
    private PlayerController playerC;
    [Space]
    public float timeBetweenLetters = 0.01f;


    void Start()
    {
        dialogues = new Queue<Dialogue>();
        playerC = FindObjectOfType<PlayerController>();

    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DisplayNextMessage();
        }
    }

    public void StartDialogue(Dialogue[] dialoguez)
    {
        playerC.SetInDialogue(true);
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
    }

    IEnumerator TypeDialogue (string sentence)
    {
        dialogueText.text = " ";
        foreach  (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(timeBetweenLetters);
            //yield return null; //kommer skriva en bokstav per frame
        }
    }

    void EndDialogue()
    {
        playerC.SetInDialogue(false);
        animator.SetBool("IsOpen", false);
    }

}
