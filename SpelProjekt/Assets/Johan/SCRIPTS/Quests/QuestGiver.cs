using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    private Player player;
    [Space]
    
    public Quest[] quests;

    private QuestHUDManager questHUD;
    public int questIndex;
    //public int dialogueIndex;
    public int questProgress; //0 = start, 1 = in progress, 2 = done

    private void Start()
    {
        player = FindObjectOfType<Player>();
        questHUD = FindObjectOfType<QuestHUDManager>();
    }

    public void OpenQuestWindow()
    {
        questHUD.OpenQuestWindow(quests[questIndex]); //Öppna windowet när man fått uppdraget
        
    }

    public void TryStartQuest()
    {
        if (questProgress == 0 && questIndex < quests.Length) //kan bara starta om man e klar med förra. Går inte starta nytt om det itne finns fler x) //&& questIndex < quests.Length
        {
            questHUD.AddQuest(quests[questIndex], this);
            OpenQuestWindow();
            questProgress = 1; // =1 ska det bli
        }

    }
    public void QuestCompletedNotFinished() //om man klarat av alla saker för uppdraget, men inte snackat med givaren än
    {
        questProgress = 2;
    }
    public void QuestFinished()
    {
        questIndex++;       
        questProgress = 0;

    }

    public void InterractedWith()
    {
        if (questIndex >= dialogues.Length)
        {
            return;
        }

        quests[questIndex].InterractedWith();
    }


    [Tooltip("Antalet såna här borde vara samma som mängden Quests")]
    public Dialogues[] dialogues;

    [System.Serializable]
    public struct Dialogues
    {
        [Tooltip("Ska alltid vara 3 st, först för när man börjar uppdraget, " +
            "andra för när man pratar innan man är klar, och tredje när man är klar!")]
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


}
