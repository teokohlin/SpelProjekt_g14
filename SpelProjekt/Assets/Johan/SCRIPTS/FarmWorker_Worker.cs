using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class FarmWorker_Worker : Worker
{
    public DialogueTrigger noPlownFieldsDialogueTrigger;
    private DayNightCycle Dnc;
    public Transform homePosition;
    public List<GameObject> fields = new List<GameObject>();
    //private List<GameObject> tempFields = new List<GameObject>();
    private GameObject currentField;
    [SerializeField]
    private BoxCollider rangeBox;
    [SerializeField]
    private float animationDelay = 1;
    [SerializeField]
    private float animationDelay2 = 1;

    private bool plantedOnField; //killedwood
    private bool inAnimation = false;

    [Tooltip("Hur m�nga f�lt som monstret kan s� per g�ng")]
    public int targets = 10; 
    private int originalTargets = 10;
    private Animator animator;

    private bool done = false;

    private NavMeshAgent agent;



    void Start()
    {


    }
    private void Awake()
    {
        originalTargets = targets;
        Energy = MaxEnergy; //Stor bokstav?

        Dnc = FindObjectOfType<DayNightCycle>();
        Dnc.DayPast += RefillEnergy;
        rangeBox = GetComponent<BoxCollider>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }


    private void OnEnable()
    {

        List<GameObject> tempFields = new List<GameObject>(GameObject.FindGameObjectsWithTag("Field")); //Skapa tillf�llig

        //L�gg till alla f�lt som �r pl�jda i listan
        foreach (var field in tempFields)
        {
            if (field.GetComponent<FieldScript>().ReturnFieldState() == 1) //Tror det var 1 som �r pl�jd
            {
                fields.Add(field);
            }
        }

        if (fields.Count <= 0)
        {
            noPlownFieldsDialogueTrigger.TriggerDialogue();
            enabled = false;
            return;
        }
        Energy--;

        SortByDistance();
        targets = originalTargets;



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
            agent.SetDestination(currentField.transform.position); //R�ra sig mot nuvaranda f�ltet
            
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
            return;
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



    void SowField()
    {
        
        //Trigga animation och delay

        StopAllCoroutines();
        StartCoroutine("WaitOnAnimation");
        

        
        //FieldScript field = fields[0].GetComponent<FieldScript>();

        //field.ChangeFarmstate();

        //plantedOnField = true;
        //if (plantedOnField)
        //{
        //    fields.Remove(field.gameObject);
        //    plantedOnField = false;
        //}
        

        //
        targets--;
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

    
    private IEnumerator WaitOnAnimation()
    {
        animator.SetTrigger("StandingUp");
        animator.SetFloat("Speed", 0);
        //agent.speed = 0;
        inAnimation = true;

        FieldScript field = fields[0].GetComponent<FieldScript>();

        plantedOnField = true;
        if (plantedOnField)
        {
            fields.Remove(field.gameObject);
            plantedOnField = false;

        }



        yield return new WaitForSeconds(animationDelay);
        

        field.ChangeFarmstate(); 
        
        yield return new WaitForSeconds(animationDelay);
        inAnimation = false;
        //agent.speed = 1;


    }
    
}
