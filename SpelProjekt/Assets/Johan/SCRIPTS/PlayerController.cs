using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine.Examples;


public class PlayerController : MonoBehaviour
{

    public Camera cam;
    public LayerMask choppableLayers;
    public LayerMask interactableLayer;
    [Space]
    public Transform chopPoint;
    public Vector3 chopBoxSize = new Vector3(.5f,4,1.75f); //trodde man skulle behöva dela på 2.       .5, 4, 1.75f är min idé bara. går ändra
    public float chopRate = 1f;
    [Space]
    public float maxDistanceForInteractions = 5f;

    private ToolSwitch toolScript;


    float nextChopTime = 0f;
    [HideInInspector]
    public Player player;

    private bool inDialogue = false;
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

    //public BlackScreenManager blackscreen;
    void Start()
    {
         toolScript = gameObject.GetComponent<ToolSwitch>();
         player = GetComponent<Player>();
         akc = GetComponent<AdditionalKeyControl>();
         as3 = GetComponent<AS3CharacterMovement>();
         //blackscreen = FindObjectOfType<BlackScreenManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (inDialogue) //Avaktiverar också för när man är i dialog
        {
            return;
        }

        //VÄNSTERKLICK

        //Har spelaren energi och har tiden sedan senaste "slaget" gått. 
        if (Time.time >= nextChopTime)
        {



            //vänsterklick
            if (Input.GetMouseButtonDown(0))
            {
                if (player.ReturnEnergy() < 1)
                {
                    player.noEnergyActivated?.Invoke();
                    return;
                }

                StopAllCoroutines();

                //vilket tool vi håller
                switch (toolScript.currentTool)
                {
                    case 0://YXA
                        akc.SetAnimationTrigger(treeChopTriggername);
                        //ChopTowardsMouse("Tree");
                        StartCoroutine(ChopTowardsMouse("Tree"));
                        break;
                    case 1: //PICKAXE
                        akc.SetAnimationTrigger(stonePickTriggername);
                        //ChopTowardsMouse("Stone");
                        StartCoroutine(ChopTowardsMouse("Stone"));
                        break;
                    case 2: //PLOG
                        akc.SetAnimationTrigger(hoeUseTriggername);
                        StartCoroutine(FarmTowardsMouse(0));
                        break;
                    case 3: //FRÖN
                        akc.SetAnimationTrigger(seedsUseTriggername);
                        StartCoroutine(FarmTowardsMouse(1));
                        break;
                    case 4: //VATTENKANNA
                        akc.SetAnimationTrigger(watercanUseTriggername);
                        StartCoroutine(FarmTowardsMouse(2));
                        break;
                    case 5: //LIE
                        akc.SetAnimationTrigger(scytheUseTriggername);
                        StartCoroutine(FarmTowardsMouse(4));
                        break;
                    default:
                        break;
                }
                //akc.SetAttack();

                nextChopTime = Time.time + 1f / chopRate;
            }
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

                if (Input.GetMouseButtonDown(1))
                {
                    if (Vector3.Distance(transform.position, interactable.gameObject.transform.position) <= maxDistanceForInteractions)
                    {
                        interactable.InteractWith(this); //släng med "playercontrollern" som referens
                    }
                }

            }
            else
            {
                //muspekare blir vanlig
            }
        }


    }



    IEnumerator ChopTowardsMouse(string resourceTag)
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
        Collider[] hitChoppables = Physics.OverlapBox(chopPoint.position, chopBoxSize, chopPoint.rotation, choppableLayers);


        if (hitChoppables.Length >= 1)
        {
            //Play hugg ANimation //animation här om den bara ska spelas om man träffar något(vad som)


            Collider closestChoppable = GetClosestEnemyCollider(transform.position, hitChoppables);

            if (closestChoppable.CompareTag(resourceTag))
            {
                //play animation här om det bara ska spelas när man slår på rätt sak
                player.UseEnergy(1);
                yield return new WaitForSeconds(timeTilDamage);
                closestChoppable.GetComponent<Choppable>().LoseHealth(1); //redskapet gör bara 1 skada just nu
            }
        }
    }

    IEnumerator FarmTowardsMouse(int neededFarmIndex)
    {
          Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100, choppableLayers))
        {
            //Vector3 targetPostition = new Vector3(hit.point.x,
            //    this.transform.position.y,
            //    hit.point.z);
            //this.transform.LookAt(targetPostition);

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
        
        Collider closestChoppable = GetClosestEnemyCollider(transform.position, hitChoppables);


        if (closestChoppable.CompareTag("Field"))
        {
            FieldScript fieldScript = closestChoppable.GetComponent<FieldScript>();
            if (fieldScript.ReturnFieldState() == neededFarmIndex)
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


    public void SetLockMovement(bool inDial) 
    {
        inDialogue = inDial;

        as3.LockMovement(inDialogue);
    }

    private void ChangeCursorSprite()
    {

    }

    private void OnDrawGizmos() //visar bara rätt om man står helt rakt som man gör i början, den vrids inte med gubben
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireCube(chopPoint.position, chopBoxSize);

    }



}
