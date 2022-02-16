using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest 
{
    [HideInInspector]
    public bool isActive;

    public string title;
    public string description;
    public Sprite rewardSprite;
    public int rewardAmount;
    public RewardType rewardKind;
    [Header("Om resource, vilken")]
    public dType rewardType;

    [Space]
    [Header("QuestGoal")]
    public QuestGoal goal;
    public enum RewardType
    {
        Resource,
        Story
    }




    public void Init()
    {
        goal.GoalCompleted += Evaluate;
        goal.Init();
    }
    public void Evaluate()
    {

        if (goal.completed == true)
        {
            Complete();
        }

    }
    public void Complete()
    {
        if (!isActive)
        {
            return;
        }


        switch (rewardKind)
        {
            case RewardType.Resource:
                RewardPlayer();
                break;
            case RewardType.Story:
                break;
            default:
                break;
        }

        Object.FindObjectOfType<QuestHUDManager>().RemoveQuest(this);
    }

    public void RewardPlayer()
    {
        switch (rewardType)
        {
            case dType.wood:
                Object.FindObjectOfType<Player>().AddWood(rewardAmount);
                break;
            case dType.stone:
                Object.FindObjectOfType<Player>().AddStone(rewardAmount);
                break;
            case dType.food:
                Object.FindObjectOfType<Player>().AddFood(rewardAmount);
                break;
            default:
                break;
        }
    }
}




