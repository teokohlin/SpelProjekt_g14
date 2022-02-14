using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldScript : MonoBehaviour
{
    [SerializeField] 
    private float growthTime = 20;
    //[SerializeField] 
    private int fieldState; //0 = ej plogad 1 = plogad 2 = sådd 3= vattnat 4 = växt
    [SerializeField] 
    private GameObject[] fields;
    //[SerializeField] 
    //private ToolSwitch Tool;
    //[SerializeField] 
    private Player p;

    //private bool farmzone;
    private float timer = 0f;
    void Start()
    {
        p = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fieldState == 3)
        {
            timer += Time.deltaTime; //måste vara deltaTime i vanlig update
            
        }
        if (timer > growthTime)
        {
            ChangeFarmstate();
            timer = 0;
        }
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
        if (fieldState > 4)
        {
            p.AddFood(10);
            fieldState = 0;
        }

        
        ChangeFieldObject();
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
    private void ChangeFieldObject()
    {
        
        for (int i = 0; i < fields.Length; i++)
        {
            if (i == fieldState)
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
