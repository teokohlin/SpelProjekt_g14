using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.AI;

public class WateringMonster : Worker
{
    private List<GameObject> fields = new List<GameObject>();

    private int targets;

    private bool done;
    
    private float happiness;
    private int maxHappiness;

    public int maxEnergy;
    private int currentEnergy;

    private NavMeshAgent agent;
    public GameObject homePosition;

    private bool isActivated;

    // Start is called before the first frame update
    void Start()
    {
        isActivated = false;

        targets = 10;

        done = false; 

        maxEnergy = 3;
        currentEnergy = 3;

        maxHappiness = 10;
        happiness = 10;
    }

    // Update is called once per frame
    void Update()
    {
        //Check if the player has activated the monster before working
        if (!isActivated)
        {
            return;
        }
        //If field list is not empty, go to the first field in the list 
        if(fields.Count > 0)
        {
          
            agent.SetDestination(fields[0].transform.position);
        } 
        else if(fields.Count <= 0 || targets <= 0)
        {
            done = true;

            //agent.SetDestination(homePosition.position);
        }
    }

    void initFields()
    {
        // Temp list of fields
        List<GameObject> tempFields = new List<GameObject>(GameObject.FindGameObjectsWithTag("Field")); 

        //Check every field in the temp list and if they aren't watered add to another list
        foreach (var field in tempFields)
        {
            //Check for sowed unwatered field tiles 
            if (field.GetComponent<FieldScript>().ReturnFieldState() == 2)
            {
                fields.Add(field);
            }
        }
    }

    private void SortByDistance()
    {
        foreach (GameObject field in fields)
        {
            fields = fields.OrderBy((field) => (field.transform.position - transform.position).sqrMagnitude).ToList();
        }
    }

    //Waters a field
    private void waterField(GameObject field)
    {
        FieldScript fs = fields[0].GetComponent<FieldScript>();

        fs.ChangeFarmstateSpecific(3);

        fields.Remove(field.gameObject);
    }

}
