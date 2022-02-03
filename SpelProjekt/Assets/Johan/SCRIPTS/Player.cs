using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] //f�r att l�ttare kunna se i unity
    private int woodAmount = 0;
    [SerializeField]
    private int stoneAmount = 0;
    [SerializeField]
    private int foodAmount = 0;

    //Hade eventuellt kunnat g�ra en klass f�r resources, wood, stone, food (vet knappt hur man g�r)

    public UnityAction<int> woodUpdate;
    public UnityAction<int> stoneUpdate;
    public UnityAction<int> foodUpdate;



    public void AddWood(int amount)
    {
        woodAmount += amount;
        woodUpdate?.Invoke(woodAmount);
    }
    public void AddStone(int amount)
    {
        stoneAmount += amount;
        stoneUpdate?.Invoke(stoneAmount);
    }
    public void AddFood(int amount)
    {
        foodAmount += amount;
        foodUpdate?.Invoke(foodAmount);
    }
}
