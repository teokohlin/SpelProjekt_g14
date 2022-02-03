using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Camera cam;
    public LayerMask choppableLayers;
    public Transform chopPoint;
    public Vector3 chopBoxSize = new Vector3(.5f,4,1.75f); //trodde man skulle beh�va dela p� 2.       .5, 4, 1.75f �r min id� bara. g�r �ndra

    public float chopRate = 1f;
    float nextChopTime = 0f;



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextChopTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ChopTowardsMouse();

                nextChopTime = Time.time + 1f / chopRate;
            }
        }



        ////////allt detta kommer kanske anv�ndas till interactables t�nker jag, typ d�rrar osv vid h�ger/v�nsterklick

        //Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        //RaycastHit hit;

        //if (Physics.Raycast(ray,out hit, 100))
        //{
        //    Interactable interactable = hit.collider.GetComponent<Interactable>();
        //    if (interactable != null)
        //    {

        //    }
        //}


    }

    private void ChopTowardsMouse()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            Vector3 targetPostition = new Vector3(hit.point.x,
                                                   this.transform.position.y,
                                                   hit.point.z);
            this.transform.LookAt(targetPostition);

        }

        Collider[] hitChoppables = Physics.OverlapBox(chopPoint.position, chopBoxSize, chopPoint.rotation, choppableLayers);


        if (hitChoppables.Length >= 1)
        {
            //Play hugg ANimation
            Collider closestChoppable = GetClosestEnemyCollider(transform.position, hitChoppables);

            closestChoppable.GetComponent<Choppable>().LoseHealth(1); //just nu g�r vi bara 1 skada :)
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


    //private void OnDrawGizmos() //visar bara r�tt om man st�r helt rakt som man g�r i b�rjan, den vrids inte med gubben
    //{
    //    Gizmos.color = Color.red;

    //    Gizmos.DrawWireCube(chopPoint.position, chopBoxSize);

    //}



}
