using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    private Player player;
    [Space]
    public Quest quest;

    private QuestHUDManager questHUD;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        questHUD = FindObjectOfType<QuestHUDManager>();
    }

    public void OpenQuestWindow()
    {
        questHUD.OpenQuestWindow(quest); //Öppna windowet när man fått uppdraget
        
    }

    public void StartQuest()
    {
        questHUD.AddQuest(quest);

    }

}
