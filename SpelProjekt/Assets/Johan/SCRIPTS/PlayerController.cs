using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine.Examples;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public ParticleSystem Particle_effect_water;
    public ParticleSystem Particle_effect_seeds;
    public Animator animator;
    public Camera cam;
    public LayerMask choppableLayers;
    public LayerMask interactableLayer;
    [Space]
    public Transform chopPoint;
    public Vector3 chopBoxSize = new Vector3(.5f,4,1.75f); //trodde man skulle behöva dela på 2.       .5, 4, 1.75f är min idé bara. går ändra
    public Vector3 farmBoxSize = new Vector3(.5f,4,2.5f);
    public float chopRate = 1f;
    [Space]
    public float maxDistanceForInteractions = 5f;
    //[Tooltip("Interaction collidern som är en trigger")]
    //public Collider interactionSphereCollider;

    private List<GameObject> interactables = new List<GameObject>();
    
    private ToolSwitch toolScript;
    private CursorScript cursor;


    float nextChopTime = 0f;
    [HideInInspector]
    public Player player;

    private bool lockMovement = false;
    private AdditionalKeyControl akc;
    private AS3CharacterMovement as3; //Behövde *using Cinemachine.Examples;

    [Header("Animation Tags")]
    public string treeChopTriggername;
    public string stonePickTriggername;
    public string hoeUseTriggername;
    public string seedsUseTriggername;
    public string watercanUseTriggername;
    public string scytheUseTriggername;
    [Space]
    public float timeTilDamage = .6f;

    private bool leftMouseIsDown;

    //public BlackScreenManager blackscreen;
    void Start()
    {
         toolScript = gameObject.GetComponent<ToolSwitch>();
         player = GetComponent<Player>();
         akc = GetComponent<AdditionalKeyControl>();
         as3 = GetComponent<AS3CharacterMovement>();
         cursor = GetComponent<CursorScript>();

         //blackscreen = FindObjectOfType<BlackScreenManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lockMovement) //Avaktiverar också för när man är i dialog
        {
            return;
        }
        
        //HÖGERKLICK

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100, interactableLayer))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                //Muspekare blir "interactable" symbol, typ hand med finger
                cursor.ChangeToInteractableCursor();

                if (Input.GetMouseButtonDown(1))
                {
                    if (interactables.Contains(interactable.gameObject))  //istället kolla om är i listan if (Vector3.Distance(transform.position, interactable.gameObject.transform.position) <= maxDistanceForInteractions)
                    {
                        interactable.InteractWith(this); //släng med "playercontrollern" som referens
                    }
                }

            }

        }
        else
        {
            //muspekare blir vanlig
            cursor.ChangeToStandardCursor();
        }
        
        
        
        




        //VÄNSTERKLICK
        
        if (Input.GetMouseButtonDown(0))
        {
            leftMouseIsDown = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            leftMouseIsDown = false;
        }
        
        

        //Har spelaren energi och har tiden sedan senaste "slaget" gått. 
        if (Time.time >= nextChopTime)
        {



            //vänsterklick
            if (leftMouseIsDown && !EventSystem.current.IsPointerOverGameObject())
            {
                nextChopTime = Time.time + 1f / chopRate;


                if (player.ReturnEnergy() < 1)
                {
                    player.noEnergyActivated?.Invoke();
                    akc.SetAnimationTrigger("Tired");
                    return;
                }

                StopAllCoroutines();

                //vilket tool vi håller
                switch (toolScript.currentTool)
                {
                    case 0://YXA
                        akc.SetAnimationTrigger(treeChopTriggername);
                        //ChopTowardsMouse("Tree");
                        StartCoroutine(ChopTowardsMouse("Tree", "TreeMisc"));
                        break;
                    case 1: //PICKAXE
                        akc.SetAnimationTrigger(stonePickTriggername);
                        //ChopTowardsMouse("Stone");
                        StartCoroutine(ChopTowardsMouse("Stone", "Stone"));
                        break;
                    case 2: //PLOG
                        akc.SetAnimationTrigger(hoeUseTriggername);
                        StartCoroutine(FarmTowardsMouse());
                        break;
                    case 3: //FRÖN
                        Particle_effect_seeds.Play();
                        akc.SetAnimationTrigger(seedsUseTriggername);
                        StartCoroutine(FarmTowardsMouse());
                        break;
                    case 4: //VATTENKANNA
                        if (player.waterAmount == 0)
                        {
                            return;
                        }
                        Particle_effect_water.Play();
                        player.DepleteWater();
                        akc.SetAnimationTrigger(watercanUseTriggername);
                        StartCoroutine(FarmTowardsMouse());
                        break;
                    case 5: //LIE
                        akc.SetAnimationTrigger(scytheUseTriggername);
                        StartCoroutine(FarmTowardsMouse());
                        break;
                    default:
                        break;
                }
                //akc.SetAttack();

            }
        }






    }

    

    IEnumerator ChopTowardsMouse(string resourceTag, string resourceTag2)
    {

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100, choppableLayers))
        {
            //Vector3 targetPostition = new Vector3(hit.point.x,
            //                                       this.transform.position.y,
            //                                       hit.point.z);

            Vector3 targetPosition = new Vector3(hit.transform.position.x,
                                                 this.transform.position.y,
                                                 hit.transform.position.z);

            this.transform.LookAt(targetPosition);

        }

        //akc.SetAttack(); ///////////hugg animation, gör detta mer specifikt för var grej

        
        //ANIMATION      //ska funka som "attack" gjorde, en funktion som kallar en "trigger" i animationskontrollen
        //KANSKE KAN HA DETTA I SWITCHEN I UPDATE ISTÄLLET
        //switch (resourceTag)
        //{
        //    case "Tree" :
        //        //akc. ChopTree();
        //        break;
        //    case "Stone" :
        //        //akc. PickStone();
        //        break;
        //    default:
        //        break;
        //}

        //CHOPBOX
        Collider[] hitChoppables = Physics.OverlapBox(chopPoint.position, farmBoxSize, chopPoint.rotation, choppableLayers);


        if (hitChoppables.Length >= 1)
        {
            //Play hugg ANimation //animation här om den bara ska spelas om man träffar något(vad som)


            Collider closestChoppable = GetClosestEnemyCollider(transform.position, hitChoppables);

            if (closestChoppable.CompareTag(resourceTag) || closestChoppable.CompareTag(resourceTag2))
            {
                //play animation här om det bara ska spelas när man slår på rätt sak
                player.UseEnergy(1);
                yield return new WaitForSeconds(timeTilDamage);
                closestChoppable.GetComponent<Choppable>().LoseHealth(1); //redskapet gör bara 1 skada just nu
            }
        }
    }

    IEnumerator FarmTowardsMouse()
    {
        GameObject clickedObject = null;

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100, choppableLayers))
        {
            //Vector3 targetPostition = new Vector3(hit.point.x,
            //    this.transform.position.y,
            //    hit.point.z);
            //this.transform.LookAt(targetPostition);

            clickedObject = hit.transform.gameObject;


                        Vector3 targetPosition = new Vector3(hit.transform.position.x,
                                                 this.transform.position.y,
                                                 hit.transform.position.z);

            this.transform.LookAt(targetPosition);



        }  

        
        //FARMBOX
        Collider[] hitChoppables = Physics.OverlapBox(chopPoint.position, chopBoxSize, chopPoint.rotation, choppableLayers);



        if (hitChoppables.Length < 1)
        {
            yield break; //return; i en vanlig funktion
        }

        //ANIMATIONS       //ska funka som "attack" gjorde, en funktion som kallar en "trigger" i animationskontrollen
        //KANSKE KAN HA DETTA I SWITCHEN I UPDATE ISTÄLLET

        //switch (neededFarmIndex)
        //{
        //    case 0: //Plog
        //        //akc. PlowField();
        //        break;
        //    case 1: //Frön
        //        //akc. SeedField();
        //        break;
        //    case 2: //Vattenkanna
        //        //akc. WaterField();
        //        break;
        //    case 3: //Lie
        //        //akc. HoeField();
        //        break;
        //    default:
        //        break;
        //}

        //Collider closestChoppable = GetClosestEnemyCollider(transform.position, hitChoppables);
        GameObject closestChoppable = null;
        bool rightOneFound = false;
        
        foreach (var item in hitChoppables)
        {
            if (GameObject.ReferenceEquals(item.gameObject, clickedObject))
            {
                closestChoppable = item.gameObject;
                rightOneFound = true;
                break;
            }
        }
        
        //Om objektet man klickat på (om man klickat på ett överhuvudtaget) inte är i spelarens range. Gör action på
        //det närmsta objektet istället
        if (!rightOneFound)
        {
            closestChoppable = GetClosestEnemyCollider(transform.position, hitChoppables).gameObject;
        }

        if (closestChoppable == null)
        {
            yield break; //return; i en vanlig funktion
        }

        if (closestChoppable.CompareTag("Field"))
        {
            FieldScript fieldScript = closestChoppable.GetComponent<FieldScript>();
            
            if (fieldScript.CanUseTool(toolScript.index))
            {
                player.UseEnergy(1);
                yield return new WaitForSeconds(timeTilDamage);
                fieldScript.ChangeFarmstate();
            }
            


        }
    }




    
    
    
    
    

    Collider GetClosestEnemyCollider(Vector3 playerPosition, Collider[] choppableColliders)
    {
        float bestDistance = 99999.0f;
        Collider bestCollider = null;

        foreach (Collider choppable in choppableColliders)
        {
            float distance = Vector3.Distance(playerPosition, choppable.transform.position);

            if (distance < bestDistance)
            {
                bestDistance = distance;
                bestCollider = choppable;
            }
        }

        return bestCollider;
    }


    public void SetLockMovement(bool lockMov) 
    {
        lockMovement = lockMov;

        as3.LockMovement(lockMovement);
    }


    //private void OnDrawGizmos() //visar bara rätt om man står helt rakt som man gör i början, den vrids inte med gubben
    //{
    //    Gizmos.color = Color.red;

    //    Gizmos.DrawWireCube(chopPoint.position, farmBoxSize);

    //}

    private void OnTriggerEnter(Collider other)
    {
        interactables.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        interactables.Remove(other.gameObject);

    }
}
