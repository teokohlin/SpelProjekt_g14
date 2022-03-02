using System.Collections;
using System.Threading;
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

    [HideInInspector]
    public bool justStarted = true;

    [Space]
    [Header("QuestGoal")]
    public QuestGoal[] goals;
    [Header("Iklickad om man INTE behöver prata med questgivern för att färdigställa questet")]
    public bool finishBeforeTalking = false;
    public enum RewardType
    {
        Resource,
        Story
    }




    public void Init()
    {
        justStarted = true; //boorde inte behövas

        foreach (QuestGoal goal in goals)
        {
            goal.quest = this;
            goal.GoalCompleted += Evaluate;
            goal.Init();
        }



        questGiver.DelayQuestActivation(this); //Behöver starta couroutine i ett skript med *MonoBehaviour*, nu QuestGiver
    }
    public void Evaluate()
    {
        foreach (QuestGoal goal in goals)
        {
            if (!goal.completed)
            {
                return;
            }
        }

        Complete();


        //if (goal.completed == true)
        //{
        //    Complete();
        //}

    }
    public void Complete()
    {
        completed = true;
        questGiver.QuestCompletedNotFinished();
    }
    public void InterractedWith() //När man interragerar med (questgivern), kolla om questet är Complete. Då ska det tas bort och så
    {

        if (completed && !justStarted)
        {

            RemoveQuest();
        }
        else if (completed && justStarted)
        {
            questGiver.questProgress = 2;
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
        Object.FindObjectOfType<Player>().AddResource(rewardAmount, rewardType);

        //switch (rewardType)
        //{
        //    case dType.wood:
        //        Object.FindObjectOfType<Player>().AddWood(rewardAmount);
        //        break;
        //    case dType.stone:
        //        Object.FindObjectOfType<Player>().AddStone(rewardAmount);
        //        break;
        //    case dType.food:
        //        Object.FindObjectOfType<Player>().AddFood(rewardAmount);
        //        break;
        //    default:
        //        break;
        //}
    }


    public IEnumerator DelaySomething()
    {
        yield return new WaitForEndOfFrame();
        justStarted = false;
    }


}




