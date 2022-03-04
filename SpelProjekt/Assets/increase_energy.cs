using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class increase_energy : MonoBehaviour
{
    public Player player;
    public int energy_increase = 10;
    // Start is called before the first frame update
    void OnEnabled()
    {
        player.maxEnergy += energy_increase;
    }

    // Update is called once per frame
    void Start()
    {
        player = FindObjectOfType<Player>();
    }
}
