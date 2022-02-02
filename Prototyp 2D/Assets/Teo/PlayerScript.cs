using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class PlayerScript : MonoBehaviour
{
    public int energi = 3;
    private Vector2 movement;
    public TreeScript[] träd;
    public RockScript[] rocks;
    public CanvasButtons canvas;
    private Rigidbody2D rb;
    public float speed = 10f;
    private bool isCurrentlyMoving;
    public AudioSource audioSource; 

    public UnityAction RefillEnergy;
    void Start()
    {
        Bedscript bed = GameObject.FindObjectOfType<Bedscript>();
        bed.Slept += AddEnergy;
        rb = this.GetComponent<Rigidbody2D>();
        canvas.Useenergi += RemoveEnergi;
        foreach (var t in träd)
         {
             t.UseEnergi += RemoveEnergi;
         }
        foreach (var rock in rocks)
        {
            rock.UseEnergy += RemoveEnergi;
        }
        
        //audioSource.Play();
    }

    private void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        //Debug.Log(energi);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

        if (movement.sqrMagnitude > 0)
        {

            if (!audioSource.isPlaying)
            {

                audioSource.UnPause(); //tror play är bäst när man har kort audiofil
            }
            
        }
        else
        {
            audioSource.Pause();
        }
    }

    public void AddEnergy()
    {
        energi = 3;
        RefillEnergy?.Invoke();
    }
    void RemoveEnergi()
    {
        energi--;
    }
}
