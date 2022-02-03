using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] //för att lättare kunna se i unity
    private int woodAmount = 0;
    [SerializeField]
    private int stoneAmount = 0;
    [SerializeField]
    private int foodAmount = 0;


    public void AddWood(int amount)
    {
        woodAmount += amount;
    }
    public void AddStone(int amount)
    {
        stoneAmount += amount;
    }
    public void AddFood(int amount)
    {
        foodAmount += amount;
    }
}
