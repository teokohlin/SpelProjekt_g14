 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
 using TMPro;
 

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
    [Space]
    //public List<Quest> quests;

    float percentage;
    public int maxWater;
    //[HideInInspector]
    public int waterAmount;
    //Hade eventuellt kunnat göra en klass för resources, wood, stone, food (vet knappt hur man gör)
    public UnityAction<int> woodIncrease;
    public UnityAction<int> stoneIncrease;
    public UnityAction<int> foodIncrease;

    public bool NoEnergy;
    [SerializeField]
    private GameObject resourceAdditionPrefab;

    [SerializeField] private GameObject parentPanel;


    public UnityAction<int> woodUpdate;
    public UnityAction<int> stoneUpdate;
    public UnityAction<int> foodUpdate;
    public UnityAction<float> energyPercentageUpdate;
    public UnityAction noEnergyActivated;
    public UnityAction noWaterActivated;


    public void AddWood(int amount)
    {
        woodAmount += amount;
        woodUpdate?.Invoke(woodAmount);

        woodIncrease?.Invoke(amount);

        SpawnText(amount);
    }
    public void AddStone(int amount)
    {
        stoneAmount += amount;
        stoneUpdate?.Invoke(stoneAmount);
        
        stoneIncrease?.Invoke(amount);
        
        SpawnText(amount);
    }
    public void AddFood(int amount)
    {
        foodAmount += amount;
        foodUpdate?.Invoke(foodAmount);

        foodIncrease?.Invoke(amount);
        
        SpawnText(amount);
    }
    public void AddResource(int amount, dType type)
    {
        switch (type)
        {
            case dType.wood:
                AddWood(amount);
                break;
            case dType.stone:
                AddStone(amount);
                break;
            case dType.food:
                AddFood(amount);
                break;
            default:
                break;
        }
    }

    public int ReturnAmount(dType type)
    {
        switch (type)
        {
            case dType.wood:
                return woodAmount;
            case dType.stone:
                return stoneAmount;
            case dType.food:
                return foodAmount;
            default:
                return 0;
                
        }
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
        NoEnergy = false;
        //percentage = energy / maxEnergy;
        //Debug.Log(percentage);
        //energyPercentageUpdate?.Invoke(percentage);
        energyPercentageUpdate?.Invoke(Percentage(energy, maxEnergy));

    }

    public void FillWater()
    {
        waterAmount = maxWater;
    }
    public void DepleteWater()
    {
        waterAmount--;
        if (waterAmount <= 0)
        {
            noWaterActivated?.Invoke();
        }
    }


    private float Percentage(float a, float b)
    {
        return a / b;
    }
    public int ReturnEnergy()
    {
        return energy;
    }

    private void SpawnText(int amount)
    {
        if (amount == 0)
        {
            return;
        }
        
        GameObject ra = Instantiate(resourceAdditionPrefab, parentPanel.transform.position, Quaternion.identity, parentPanel.transform);

        if (amount > 0)
        {
            ra.GetComponent<TextMeshProUGUI>().text = "+ " + amount.ToString();
        }
        else
        {
            int tempAmount = amount * -1;
            ra.GetComponent<TextMeshProUGUI>().text = "- " + tempAmount.ToString();
        }
        
    }
}
