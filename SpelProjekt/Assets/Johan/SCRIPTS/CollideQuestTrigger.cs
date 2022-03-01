using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(QuestGiver))]
public class CollideQuestTrigger : MonoBehaviour
{
    bool questStarted = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!questStarted)
        {
            GetComponent<QuestGiver>().TriggerDialogue();
            GetComponent<QuestGiver>().TryStartQuest();
            GetComponent<QuestGiver>().InterractedWith();   
            questStarted = true;
            enabled = false;
        }

    }
}
