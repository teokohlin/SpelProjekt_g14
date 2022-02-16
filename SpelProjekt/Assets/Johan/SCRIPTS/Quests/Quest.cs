using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest 
{
    public bool isActive;

    public string title;
    public string description;
    public Sprite rewardSprite;
    public int rewardAmount;

    public QuestGoal goal;

    public void Evaluate()
    {
        if (goal.completed == true)
        {
            Complete();
        }
    }
    public void Complete()
    {
        isActive = false;
    }
}
