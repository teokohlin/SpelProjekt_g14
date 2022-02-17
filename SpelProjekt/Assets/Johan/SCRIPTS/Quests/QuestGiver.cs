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
    public int dialogueIndex;
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

    public void StartQuest()
    {
        questHUD.AddQuest(quests[questIndex]);
        OpenQuestWindow();
    }
    public void QuestFinished()
    {
        questIndex++;
    }

}
