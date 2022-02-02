using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEvent : MonoBehaviour
{

    // We create a variable capable of containing all values in the box collider of the hand.

    private ParticleSystem myParticles;


    void Start()
    {

    	myParticles = GameObject.Find("PlayerAttack_PAS").GetComponent<ParticleSystem>();
       
    }
    
    public void ParticleEffectHand()
    {
	myParticles.Play();
    }

}
