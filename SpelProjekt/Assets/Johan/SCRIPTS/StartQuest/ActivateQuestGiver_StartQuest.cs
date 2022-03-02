using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateQuestGiver_StartQuest : StartQuest
{
    public override void StartSomething()
    {
        base.StartSomething();

        GetComponent<QuestGiver>().enabled = true;
        GetComponent<Interactable>().enabled = true;
    }
}
