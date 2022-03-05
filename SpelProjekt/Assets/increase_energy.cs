using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class increase_energy : MonoBehaviour
{
    public Player player;

    public int energy_increase = 10;
    public void Start()
    {
        player = FindObjectOfType<Player>();
    }
    public void OnEnabled()
    {
        player.maxEnergy += energy_increase;
    }

}
