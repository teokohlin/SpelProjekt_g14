using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Camera cam;
    public LayerMask choppableLayers;
    public LayerMask interactableLayer;
    public Transform chopPoint;
    public Vector3 chopBoxSize = new Vector3(.5f,4,1.75f); //trodde man skulle behöva dela på 2.       .5, 4, 1.75f är min idé bara. går ändra
    private ToolSwitch toolScript;
    public float chopRate = 1f;
    public float maxDistanceForInteractions = 5f;

    float nextChopTime = 0f;
    [HideInInspector]
    public Player player;

    private bool inDialogue = false;
    public AdditionalKeyControl akc;

    

    void Start()
    {
         toolScript = gameObject.GetComponent<ToolSwitch>();
         player = GetComponent<Player>();
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

                //vilket tool vi håller
                switch (toolScript.currentTool)
                {
                    case 0://YXA
                        ChopTowardsMouse("Tree");
                        break;
                    case 2: //PLOG
                        break;
                    case 1: //PICKAXE
                        ChopTowardsMouse("Stone");
                        break;
                    case 3: //HOE
                        break;
                    case 4: //VATTENKANNA
                        break;
                    default:
                        break;
                }

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

    private void ChopTowardsMouse(string resourceTag) //"Tree" , "Stone"
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100, choppableLayers))
        {
            Vector3 targetPostition = new Vector3(hit.point.x,
                                                   this.transform.position.y,
                                                   hit.point.z);
            this.transform.LookAt(targetPostition);

        }

        akc.SetAttack(); //hugg animation

        Collider[] hitChoppables = Physics.OverlapBox(chopPoint.position, chopBoxSize, chopPoint.rotation, choppableLayers);


        if (hitChoppables.Length >= 1)
        {
            //Play hugg ANimation //


            Collider closestChoppable = GetClosestEnemyCollider(transform.position, hitChoppables);
            //if closestChopable == tree && currentTool == 0
            /*
            if (closestChoppable.CompareTag("Tree") && toolScript.currentTool == 0)
            {
                closestChoppable.GetComponent<Choppable>().LoseHealth(1); //just nu gör vi bara 1 skada :)
            }
            else if (closestChoppable.CompareTag("Stone") && toolScript.currentTool == 2)
            {
                closestChoppable.GetComponent<Choppable>().LoseHealth(1); //just nu gör vi bara 1 skada :)

            } */

            if (closestChoppable.CompareTag(resourceTag))
            {
                closestChoppable.GetComponent<Choppable>().LoseHealth(1);
                player.UseEnergy(1);
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


    public void SetInDialogue(bool inDial)
    {
        inDialogue = inDial;
    }

    //private void OnDrawGizmos() //visar bara rätt om man står helt rakt som man gör i början, den vrids inte med gubben
    //{
    //    Gizmos.color = Color.red;

    //    Gizmos.DrawWireCube(chopPoint.position, chopBoxSize);

    //}



}
