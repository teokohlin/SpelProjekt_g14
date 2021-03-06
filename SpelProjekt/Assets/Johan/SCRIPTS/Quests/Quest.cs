using System.Collections;
using System.Threading;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

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
    [Header("StartQuest-skript som ska startas när questet startas/avklaras")]
    public StartQuest[] questStartScripts; 
    public StartQuest[] questEndScripts;
    [HideInInspector]
    public bool justStarted = true;
    private bool gatheredButNotComplete = false;

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

        Object.FindObjectOfType<DialogueManager>().dialogueEnd += OnDialogueEnd;

        foreach (QuestGoal goal in goals)
        {
            goal.quest = this;
            goal.GoalCompleted += Evaluate;
            goal.GoalNotCompleted += Evaluate;
            goal.Init();
        }


        //Starta eventuellt skript i valfritt objekt
        if (questStartScripts != null)
        {
            foreach (var questStartScript in questStartScripts)
            {
                questStartScript.StartSomething();
            }
            
        }
        



        questGiver.DelayQuestActivation(this); //Behöver starta couroutine i ett skript med *MonoBehaviour*, nu QuestGiver
    }
    public void Evaluate()
    {
        foreach (QuestGoal goal in goals)
        {
            if (!goal.completed)
            {
                UnComplete();
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
        gatheredButNotComplete = true;
        if (justStarted)
        {
            return;
        }
        completed = true;
        questGiver.QuestCompletedNotFinished();
    }

    public void UnComplete()
    {
        if (completed = false)
        {
            return;
        }
        gatheredButNotComplete = false;

        completed = false;
        questGiver.QuestNotCompletedAnymore();
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
    public void RemoveQuest() //Totalt completad
    {
        switch (rewardKind)
        {
        case RewardType.Resource:
            Object.FindObjectOfType<DialogueManager>().dialogueEnd += RewardPlayer;
            //RewardPlayer();
            break;
        case RewardType.Story:
            break;
        default:
            break;
        }

        if (questEndScripts != null)
        {
            foreach (var questEndScript in questEndScripts)
            {
                questEndScript.StartSomething();
            }
        }

        Object.FindObjectOfType<QuestHUDManager>().RemoveQuest(this);
        
    }



    public void RewardPlayer()
    {
        
        
        Object.FindObjectOfType<Player>().AddResource(rewardAmount, rewardType);
        Object.FindObjectOfType<DialogueManager>().dialogueEnd -= RewardPlayer;

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


    public void OnDialogueEnd()
    {
        if (gatheredButNotComplete && !completed)
        {
            Object.FindObjectOfType<DialogueManager>().dialogueEnd -= OnDialogueEnd;
            Complete();
        }
    }


    public IEnumerator DelaySomething()
    {
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        justStarted = false;
    }


}




