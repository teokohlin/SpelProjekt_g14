using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class QuestGoal
{
    public GoalType goalType;
    [HideInInspector]
    public bool completed;
    //[HideInInspector]
    public int currentAmount = 0;
    public int requiredAmount = 1;

    public Sprite requiredResourceSprite;
    [Space]
    [Header("Required type, för gather eller interract")]

    public dType gatherType;

    public InterractableType interractableType;
    public GameObject repairObject;
    public GameObject findSomeoneObject;

    [Header("Iklickad om man INTE behöver prata med questgivern för att färdigställa questet")]
    public bool finishBeforeTalking = false;
    public UnityAction GoalCompleted;
    [HideInInspector]
    [System.NonSerialized] public Quest quest;

    public void Init()
    {
        switch (goalType)
        {
            case GoalType.Gathering:

                switch (gatherType)
                {
                    case dType.wood:
                        Object.FindObjectOfType<Player>().woodIncrease += ResourceGathered;
                        break;
                    case dType.stone:
                        Object.FindObjectOfType<Player>().stoneIncrease += ResourceGathered;
                        break;
                    case dType.food:
                        Object.FindObjectOfType<Player>().foodIncrease += ResourceGathered;
                        break;
                    default:
                        break;
                }


                break;
            case GoalType.Interact:
                switch (interractableType)
                {
                    case InterractableType.BunnyHole:
                        Object.FindObjectOfType<RabbitHole_Interractable>().interractedWith += Interacted;
                        Object.FindObjectOfType<RabbitHole_Interractable>().isQuest = true;
                        break;
                    case InterractableType.Repair:
                        repairObject.GetComponent<Interactable>().repaired += Repaired;                 //prenumerera på repairobjects "repairfunktion" som inte finns nu, 
                        repairObject.GetComponent<Interactable>().isQuest = true;                       //repairfunktionen på objektet ska kallas på när man klickar på knappen på canvaset
                        repairObject.GetComponent<RepairQuest_Interractable>().questGiver = quest.questGiver;   //som är kopplat till det
                        break;
                    case InterractableType.FindSomeone:
                         findSomeoneObject.GetComponent<Interactable>().interractedWith += Interacted;
                         findSomeoneObject.GetComponent<Interactable>().isQuest = true;
                        break;        
                    default:
                        break;
                }
                break;
            case GoalType.Build:
                break;
            default:
                break;
        }
    }

    
    private void ResourceGathered(int amount)
    {
        currentAmount += amount;
        currentAmount = Mathf.Clamp(currentAmount,0,requiredAmount);
        Evaluate();
    }
    
    public void BuildingBuilt()
    {
        currentAmount++;
        Evaluate();
    }
    public void Repaired()
    {
        currentAmount++;
        currentAmount = Mathf.Clamp(currentAmount,0,requiredAmount);
        Evaluate();
    }
    public void Interacted()
    {
        currentAmount++;
        currentAmount = Mathf.Clamp(currentAmount,0,requiredAmount);
        Evaluate();
    }


    public void Evaluate()
    {
        if (currentAmount >= requiredAmount)
        {
            Complete();
        }
    }

    public void Complete()
    {
        if (completed == false)
        {
            completed = true;
            GoalCompleted?.Invoke();
        }

    }



}

public enum GoalType
{
    Gathering,
    Interact,
    Build
}

public enum InterractableType
{
    BunnyHole,
    Repair,
    FindSomeone,
    annat
}