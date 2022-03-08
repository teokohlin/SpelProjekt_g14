using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldScript : MonoBehaviour
{
    
    private DayNightCycle DNC;
    private FieldType type;
    private int fieldState;
    private int wheatState, carrotState, CabbageState;
    [SerializeField] 
    private List<GameObject> fields = new List<GameObject>();
    [SerializeField] 
    private GameObject[] wheat;
    [SerializeField] 
    private GameObject[] carrots;
    [SerializeField] 
    private GameObject[] cabbage;
    private Player p;
    private UiScript ui;
    public int WheatYield, CarrotYield, CabbageYield;
    private int foodYield;

    void Start()
    {
        AddFieldList(2);
        ui = FindObjectOfType<UiScript>();
        p = FindObjectOfType<Player>();
        DNC = FindObjectOfType<DayNightCycle>();
        DNC.DayPast += GrowField;
        ui.SeedIndex += AddFieldList;
    }

    public void AddFieldList(int index)
    {
        if (fieldState < 2)
        {
            while (fields.Count > 4)
            {
                fields.Remove(fields[4]);
            }
            switch (index)
            {
                case 0:
                    type = FieldType.Cabbage;
                    foodYield = CabbageYield;
                    for (int i = 0; i < cabbage.Length; i++)
                    {
                        fields.Add(cabbage[i]);
                    }
                    break;
                case 1:
                    type = FieldType.Carrot;
                    foodYield = CarrotYield;
                    for (int i = 0; i < carrots.Length; i++)
                    {
                        fields.Add(carrots[i]);
                    }
                    break;
                case 2:
                    type = FieldType.Wheat;
                    foodYield = WheatYield;
                    for (int i = 0; i < wheat.Length; i++)
                    {
                        fields.Add(wheat[i]);
                    }
                    break;
            }
        }
    }

    public bool CanUseTool(int toolIndex)
    {
        switch (toolIndex)
        {
            case 2:
                if (fieldState == 0)
                {
                    return true;
                }
                break;
            case 3:
                if (fieldState == 1)
                {
                    return true;
                }
                break;
            case 4:
                return WaterIndexes();
            break;
            case 5:
                if (fieldState == fields.Count -1)
                {
                    return true;
                }
                break;
        }

        return false;

    }

    private bool WaterIndexes()
    {
        switch (type)
        {
            case FieldType.Cabbage:
                if (fieldState == 2 || fieldState == 4 || 
                    fieldState == 6 || fieldState == 8 || fieldState == 10)
                {
                    return true;
                }
                break;
            
            case FieldType.Carrot:
                if (fieldState == 2 || fieldState == 4 ||
                    fieldState == 6 || fieldState == 8)
                {
                    return true;
                }
                break;
            
            case FieldType.Wheat:
                if (fieldState == 2 || fieldState == 4 || 
                    fieldState == 6)
                {
                    return true;
                }
                break;
        }

        return false;
    }
    private void GrowField()
    {
        switch (type)
        {
            case FieldType.Cabbage:
                if (fieldState == 3 || fieldState == 5 || 
                    fieldState == 7 || fieldState == 9 || fieldState == 11)
                {
                    ChangeFarmstate();
                }
                break;
            
            case FieldType.Carrot:
                if (fieldState == 3 || fieldState == 5 || fieldState == 7 || fieldState == 9)
                {
                    ChangeFarmstate();
                }
                break;
            
            case FieldType.Wheat:
                if (fieldState == 3 || fieldState == 5 || fieldState ==7)
                {
                    ChangeFarmstate();
                }
                break;
        }
    }
    
    public void ChangeFarmstate()
    {
        fieldState++;
        if (fieldState > fields.Count - 1)
        {
            p.AddFood(foodYield);
            fieldState = 0;
        }

        
        ChangeFieldObject(fieldState);
    }

    
    private void ChangeFieldObject(int state)
    {
        
        for (int i = 0; i < fields.Count; i++)
        {
            if (i == state)
            {
                fields[i].gameObject.SetActive(true);
            }
            else
            {
                fields[i].gameObject.SetActive(false);
            }
        }
    }

    public int ReturnFieldState()
    {
        return fieldState;
    }
}

public enum FieldType
{
    Cabbage,
    Carrot,
    Wheat
}
