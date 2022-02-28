using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldScript : MonoBehaviour
{
    
    private DayNightCycle DNC;
    [Tooltip("Så många dagar man måste vattna")]
    //public int GrowthTime;
    private int dayCount = 0;
    
    //[SerializeField] 
    private int fieldState; //0 = ej plogad 1 = plogad 2 = sådd 3= vattnat 4 = växt
    [SerializeField] 
    private GameObject[] fields;
    //[SerializeField] 
    //private ToolSwitch Tool;
    //[SerializeField] 
    private Player p;
    public int foodYield = 5;

    //private bool farmzone;
    private float timer = 0f;
    void Start()
    {
        p = FindObjectOfType<Player>();
        DNC = FindObjectOfType<DayNightCycle>();
        //DNC.DayPast += DayCount;
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

    /*private void DayCount(int day)
    {
        if (fieldState == 3)
        {
            dayCount += day;
        }
        if (dayCount == GrowthTime && fieldState == 3)
        {
            ChangeFarmstate();
            dayCount = 0;
        }
        else if (fieldState == 3)
        {
            fieldState--;
            ChangeFieldObject(fieldState);
        }
    }*/

    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            farmzone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        farmzone = false;
    }
    */
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

    /*
    private bool NeededTool()
    {
        if (fieldState == 0 && Tool.currentTool == 2)
        {
            return true;
        }
        if (fieldState == 1 && Tool.seed)
        {
            return true;
        }
        if (fieldState == 2 && Tool.currentTool == 3)
        {
            return true;
        }
        if (fieldState == 4 && Tool.currentTool == 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    */
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
