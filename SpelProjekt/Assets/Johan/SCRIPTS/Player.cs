using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] //för att lättare kunna se i unity
    private int woodAmount = 0;
    [SerializeField]
    private int stoneAmount = 0;
    [SerializeField]
    private int foodAmount = 0;

    //Hade eventuellt kunnat göra en klass för resources, wood, stone, food (vet knappt hur man gör)

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
