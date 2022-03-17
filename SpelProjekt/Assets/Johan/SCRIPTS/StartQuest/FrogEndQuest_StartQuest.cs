using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogEndQuest_StartQuest : StartQuest
{
    [SerializeField]
    private QuestTrigger_Interractable questTriggerInterractable;
    [SerializeField] private GameObject fishingRod;
    [SerializeField]
    private Animator animator;

    private void Awake()
    {
        questTriggerInterractable = GetComponent<QuestTrigger_Interractable>();
        //animator = GetComponent<Animator>();
    }

    public override void StartSomething()
    {
        base.StartSomething();
        animator.SetBool("Trigger", true);
        fishingRod.SetActive(true);
        
        Destroy(questTriggerInterractable);
    }
}
