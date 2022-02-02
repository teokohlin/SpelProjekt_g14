using UnityEngine;
using System.Collections;
using Cinemachine.Examples;

public class AdditionalKeyControl : MonoBehaviour
{
    // We create a variable capable of containing all values in a Animator-component.

    private Animator myAnimator;

    // We create a variable capable of containing all values in the AS3CharacterMovement script.

    private AS3CharacterMovement myScriptLocomotion;


    void Start()
    {
        // We link our variable to the Animator-component and the variables thereinn.

        myAnimator = GetComponent<Animator>();

        // We link our variable to the AS3CharacterMovement script and the variables thereinn.

        myScriptLocomotion = GetComponent<AS3CharacterMovement>();

        // Just to make sure we give all our variables false statements when the scene starts.

        myAnimator.SetBool("Jump", false);
        myAnimator.SetBool("Strafing", false);

        // Make sure that the AS3CharacterMovement script is enabled when the scene starts.
       
	myScriptLocomotion.enabled = true;

       
    }

    void Update()
    {
        // When the key/button is pressed the variable becomes true.

        if (Input.GetKeyDown("space"))
        {
            myAnimator.SetBool("Jump", true);
        }

        if (Input.GetMouseButtonDown(0))
        {
            myAnimator.SetTrigger("Attack");
        }

        if (Input.GetMouseButtonDown(1))
        {
            myAnimator.SetBool("Strafing", true);
 	
	// Turns off the AS3CharacterMovement script to allow proper strafing.
        
	    myScriptLocomotion.enabled = false;
        }

        // When the key/button is released the variable becomes false.

        if (Input.GetKeyUp("space"))
        {
            myAnimator.SetBool("Jump", false);
        }

        if (Input.GetMouseButtonUp(1))
        {

	// Turns on the AS3CharacterMovement script to allow proper locomotion.

            myScriptLocomotion.enabled = true;

            myAnimator.SetBool("Strafing", false);
        }
    }
}