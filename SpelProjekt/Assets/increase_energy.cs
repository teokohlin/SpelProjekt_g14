using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class increase_energy : MonoBehaviour
{
    public Player player;

    public int energyIncrease = 10;
    //public void Start()
    //{
    //    player = FindObjectOfType<Player>();
    //}
    //public void OnEnabled()
    //{
    //    player.maxEnergy += energyIncrease;
    //    Debug.Log("hejsan Johan");
    //}
    public void Awake()
    {
        player.maxEnergy += energyIncrease;
        Debug.Log("hejsan Johan");
    }
}
