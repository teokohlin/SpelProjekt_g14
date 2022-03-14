using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogEndQuest_StartQuest : StartQuest
{
    [SerializeField]
    private QuestTrigger_Interractable questTriggerInterractable;


    private void Awake()
    {
        questTriggerInterractable = GetComponent<QuestTrigger_Interractable>();
    }

    public override void StartSomething()
    {
        base.StartSomething();
        
        Destroy(questTriggerInterractable);
    }
}
