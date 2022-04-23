using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class energyCounter : MonoBehaviour
{
    private Player player;
    private int currentEnergy;
    private int energyCap;
    public TextMeshProUGUI energyCount;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame

    // Gets current and max energy from the player component and returns a current energy / max energy string to print show on screen
    void Update()
    {
        currentEnergy = player.GetComponent<Player>().getCurrentEnergy();
        energyCap = player.GetComponent<Player>().getMaxEnergy();

        energyCount.text = currentEnergy.ToString() + "/" + energyCap.ToString();
    }

}
