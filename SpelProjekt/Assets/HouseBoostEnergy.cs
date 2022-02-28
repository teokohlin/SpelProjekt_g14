using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseBoostEnergy : MonoBehaviour
{
    public Player player;
    public int energyIncrease = 5;
    private void Start()
    {
        //player = FindObjectOfType<Player>();
    }
    private void OnEnable()
    {
        player.maxEnergy += energyIncrease;
        player.UseEnergy(0);
    }
}
