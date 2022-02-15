using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal 
{
    public bool completed;
    public int currentAmount;
    public int requiredAmount = 1;

    public virtual void Init()
    {

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
    }
}
