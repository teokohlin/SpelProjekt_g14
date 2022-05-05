using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterHole : MonoBehaviour
{
    private bool inSideTrigger = false;
    public Player player;
    private AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && inSideTrigger)
        {
            player.FillWater();
            audioManager.interactablesAudio.WaterRefillAudio(player.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.GetComponent<Player>();
            inSideTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inSideTrigger = false;
            player = null;
        }
    }
}
