using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldScript : MonoBehaviour
{
    
    private DayNightCycle DNC;
    private int dayCount = 0;
    
    //[SerializeField] 
    private int fieldState;
    [SerializeField] 
    private GameObject[] fields;

    public GameObject[] finalStage;
    //[SerializeField] 
    //private ToolSwitch Tool;
    //[SerializeField] 
    private Player p;
    private UiScript ui;
    public int foodYield = 5;

    //private bool farmzone;
    private float timer = 0f;
    void Start()
    {
        ChangeLastElement(2);
        ui = FindObjectOfType<UiScript>();
        p = FindObjectOfType<Player>();
        DNC = FindObjectOfType<DayNightCycle>();
        DNC.DayPast += GrowField;
        ui.SeedIndex += ChangeLastElement;
    }

    public void ChangeLastElement(int index)
    {
        for (int i = 0; i < finalStage.Length; i++)
        {
            if (i == index && fieldState < 2)
            {
                fields[8] = finalStage[i];
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
        
        /*
        if (farmzone && NeededTool())
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                p.UseEnergy(1);
                ChangeFarmstate();
            }
        } */
    }

    private void GrowField()
    {
        if (fieldState == 3 || fieldState == 5 || fieldState == 7)
        {
            ChangeFarmstate();
        }
    }
    
    public void ChangeFarmstate()
    {
        fieldState++;
        if (fieldState > 8)
        {
            p.AddFood(foodYield);
            fieldState = 0;
        }

        
        ChangeFieldObject(fieldState);
    }

    
    private void ChangeFieldObject(int state)
    {
        
        for (int i = 0; i < fields.Length; i++)
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
