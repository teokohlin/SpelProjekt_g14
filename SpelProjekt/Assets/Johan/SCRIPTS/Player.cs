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
    [SerializeField]
    private int energy = 5;
    [SerializeField]
    public int maxEnergy = 5;

    float percentage;

    //Hade eventuellt kunnat göra en klass för resources, wood, stone, food (vet knappt hur man gör)

    public UnityAction<int> woodUpdate;
    public UnityAction<int> stoneUpdate;
    public UnityAction<int> foodUpdate;
    public UnityAction<float> energyPercentageUpdate;
    public UnityAction noEnergyActivated;


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
    public void UseEnergy(int amount)
    {
        energy -= amount;
        if (energy <= 0)
        {
            noEnergyActivated?.Invoke();
        }
        //percentage = energy / maxEnergy;
        //Debug.Log(percentage);
        energyPercentageUpdate?.Invoke(Percentage(energy, maxEnergy));
    }

    //--------------------------------------------------

    public void RefillEnergy()
    {
        energy = maxEnergy;
        //percentage = energy / maxEnergy;
        //Debug.Log(percentage);
        //energyPercentageUpdate?.Invoke(percentage);
        energyPercentageUpdate?.Invoke(Percentage(energy, maxEnergy));

    }




    private float Percentage(float a, float b)
    {
        return a / b;
    }
    public int ReturnEnergy()
    {
        return energy;
    }
}
