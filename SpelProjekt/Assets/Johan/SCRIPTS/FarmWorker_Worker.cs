using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class FarmWorker_Worker : Worker
{
    private DayNightCycle Dnc;
    public Transform homePosition;
    public List<GameObject> fields = new List<GameObject>();
    //private List<GameObject> tempFields = new List<GameObject>();
    private Vector3 currentFieldPos;
    private GameObject currentField;
    private Vector3 newdirection;
    private Vector3 targetDir;
    [SerializeField]
    private BoxCollider rangeBox;
    [SerializeField]
    private float animationDelay = 1;

    private bool plantedOnField; //killedwood
    private bool inAnimation = false;

    [Tooltip("Hur många fält som monstret kan så per gång")]
    public int targets = 10; 
    private Animator animator;

    private bool done = false;

    private NavMeshAgent agent;



    void Start()
    {
        Dnc = FindObjectOfType<DayNightCycle>();
        Dnc.DayPast += RefillEnergy;
        rangeBox = GetComponent<BoxCollider>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }


    private void OnEnable()
    {
        Debug.Log("Enable");
        Energy--;
        List<GameObject> tempFields = new List<GameObject>(GameObject.FindGameObjectsWithTag("Field")); //Skapa tillfällig

        //Lägg till alla fält som är plöjda i listan
        foreach (var field in tempFields)
        {
            if (field.GetComponent<FieldScript>().ReturnFieldState() == 1) //Tror det var 1 som är plöjd
            {
                fields.Add(field);
            }
        }

        SortByDistance();
        //GetFieldPos();
        targets = 10;

        if (fields.Count <= 0)
        {
            enabled = false;
            return;
        }

        currentField = fields[0];
    }



    void Update()
    {
        if (inAnimation)
        {
            return;
        }

        animator.SetFloat("Speed", .5f);
        if (fields.Count > 0 && targets > 0 )
        {
            agent.SetDestination(currentField.transform.position); //Röra sig mot nuvaranda fältet
            
        }

        //Sow one and move on to the next
        if (fields.Count > 0 && rangeBox.bounds.Contains(currentField.transform.position) && targets > 0)
        {
            if (!plantedOnField)
            {
                SowField();
            }
            SortByDistance();
            if (fields.Count > 0)
            {
                currentField = fields[0];
            }
            
        }

        //When fields is empty or no targets left
        if (fields.Count  <= 0 || targets <= 0)
        {
            done = true;

            agent.SetDestination(homePosition.position);
        }

        if (rangeBox.bounds.Contains(homePosition.position) && done)
        {
            done = false;
            enabled = false;
            animator.SetFloat("Speed", 0.0f);
        }

    }






    private void GetFieldPos()
    {
        foreach (GameObject field in fields) //Glömt hur man kommer åt något i en list? xD
        {
            Vector3 vector = new Vector3(field.transform.position.x, 0.5f, field.transform.position.z);
            currentFieldPos = vector;
            break;
        }
    }

    void SowField()
    {
        //Trigga animation och delay
        //animator.SetTrigger("StandingUp");
        //animator.SetFloat("Speed", 0);
        //agent.speed = 0;
        //inAnimation = true;
        //StopAllCoroutines();
        //StartCoroutine("WaitOnAnimation");


        FieldScript field = fields[0].GetComponent<FieldScript>();

        field.ChangeFarmstate();

        plantedOnField = true;
        if (plantedOnField)
        {
            fields.Remove(field.gameObject);
            plantedOnField = false;
        }

    }

    private void RefillEnergy()
    {
        Energy = MaxEnergy;
    }
    private void SortByDistance()
    {
        foreach (GameObject field in fields)
        {
            fields = fields.OrderBy((field) => (field.transform.position - transform.position).sqrMagnitude).ToList();
        }
    }

    //private IEnumerator WaitOnAnimation()
    //{
    //    yield return new WaitForSeconds(animationDelay);
    //    agent.speed = 1;
    //    inAnimation = false;

    //    FieldScript field = fields[0].GetComponent<FieldScript>();

    //    field.ChangeFarmstate();

    //    plantedOnField = true;
    //    if (plantedOnField)
    //    {
    //        fields.Remove(field.gameObject);
    //        plantedOnField = false;
    //    }


    //}
}
