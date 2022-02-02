using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandColliderEvents : MonoBehaviour
{

    // We create a variable capable of containing all values in the box collider of the hand.

    private BoxCollider myBoxCollider;


    void Start()
    {

     myBoxCollider = GameObject.Find("HandCollider").GetComponent<BoxCollider>();   
     myBoxCollider.enabled = false;

    }


    public void TurnOnHandCollider()
    {
            myBoxCollider.enabled = true;
    }
    
    public void TurnOffHandCollider()
    {
            myBoxCollider.enabled = false;
    }

}
