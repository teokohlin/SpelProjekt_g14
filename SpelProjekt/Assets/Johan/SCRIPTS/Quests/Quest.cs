using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest 
{
    [HideInInspector]
    public bool isActive;

    [HideInInspector]
    public QuestGiver questGiver;

    public string title;
    public string description;
    public Sprite rewardSprite;
    public int rewardAmount;
    public RewardType rewardKind;
    [Header("Om resource, vilken")]
    public dType rewardType;
    [HideInInspector]
    public bool completed;

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
        completed = true;
        questGiver.QuestCompletedNotFinished();
    }
    public void InterractedWith() //När man interragerar med (questgivern), kolla om questet är Complete. Då ska det tas bort och så
    {

        if (completed)
        {

            RemoveQuest();
        }
    }
    public void RemoveQuest()
    {
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




