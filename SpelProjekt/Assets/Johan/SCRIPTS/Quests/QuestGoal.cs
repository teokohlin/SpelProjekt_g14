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


    public UnityAction GoalCompleted;

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
                    case InterractableType.RabbitHole:
                        Object.FindObjectOfType<RabbitHole_Interractable>().interractedWith += Interacted;
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
        completed = true;
        GoalCompleted?.Invoke();
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
    RabbitHole,
    annat
}