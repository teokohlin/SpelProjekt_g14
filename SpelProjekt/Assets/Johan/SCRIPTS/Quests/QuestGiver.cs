using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    public GameObject exclamationMark;
    public GameObject questionMark;
    [SerializeField]
    private Player player;
    [Space]
    
    public Quest[] quests;
    [SerializeField]
    private QuestHUDManager questHUD;
    public int questIndex;
    //public int dialogueIndex;
    public int questProgress; //0 = start, 1 = in progress, 2 = done

    private void Start()
    {
        player = FindObjectOfType<Player>();
        questHUD = FindObjectOfType<QuestHUDManager>();
    }
    private void OnEnable()
    {
        exclamationMark.SetActive(true);
        player = FindObjectOfType<Player>();
        questHUD = FindObjectOfType<QuestHUDManager>();
    }

    public void OpenQuestWindow()
    {
        questHUD.OpenQuestWindow(quests[questIndex]); //�ppna windowet n�r man f�tt uppdraget
        
    }

    public void TryStartQuest()
    {
        if (questProgress == 0 && questIndex < quests.Length) //kan bara starta om man e klar med f�rra. G�r inte starta nytt om det itne finns fler x) //&& questIndex < quests.Length
        {
            questHUD.AddQuest(quests[questIndex], this);
            OpenQuestWindow();
            questProgress = 1; // = 1 ska det bli
            exclamationMark.SetActive(false);

        }

    }
    public void QuestCompletedNotFinished() //om man klarat av alla saker f�r uppdraget, men inte snackat med givaren �n 
    {
        questProgress = 2;
        if (questIndex >= quests.Length ) 
        {
            return;
        }
        if (quests[questIndex].finishBeforeTalking) //undantaget.. Om man ska klara uppdraget utan att snacka 
        {
            TriggerDialogue();
            quests[questIndex].RemoveQuest();
        }
        else
        {
            questionMark.SetActive(true);
        }

    }
    public void QuestFinished()
    {
     
        questProgress = 0;
        questIndex++;
        if (questIndex > quests.Length - 1)
        {
            exclamationMark.SetActive(false);
        }
        else
        {
            exclamationMark.SetActive(true);
            questionMark.SetActive(false);
        }
    }

    public void InterractedWith()
    {
        if (questIndex >= dialogues.Length)
        {
            return;
        }

        quests[questIndex].InterractedWith();
    }


    [Tooltip("Antalet s�na h�r borde vara samma som m�ngden Quests")]
    public Dialogues[] dialogues;

    [System.Serializable]
    public struct Dialogues
    {
        [Tooltip("Ska alltid vara 3 st, f�rst f�r n�r man b�rjar uppdraget, " +
            "andra f�r n�r man pratar innan man �r klar, och tredje n�r man �r klar!")]
        public Dial[] dials;
    }
    [System.Serializable]
    public struct Dial
    {
        public Dialogue[] dialogue;
    }
    public void TriggerDialogue()
    {
        if (questIndex >= dialogues.Length)
        {
            return;
        }
        FindObjectOfType<DialogueManager>().StartDialogue(dialogues[questIndex].dials[questProgress].dialogue);
        

    }

    public void DelayQuestActivation(Quest quest)
    {
        StartCoroutine(quest.DelaySomething());
    }


}
