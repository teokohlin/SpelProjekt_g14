using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterHole : MonoBehaviour
{
    private bool inSideTrigger = false;
    public Player player;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && inSideTrigger)
        {
            player.FillWater();
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
