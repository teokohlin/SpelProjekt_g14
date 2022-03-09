using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoEnergyMessage : MonoBehaviour
{
    public DialogueTrigger dialogueTriggerEnergy;
    public DialogueTrigger dialogueTriggerWater;
    private Player player;
    private bool energyTrigged = false, waterTrigged = false; 

    private void Start()
    {
        player = GetComponent<Player>();
        player.noEnergyActivated += TriggerNoEnergy;
        player.noWaterActivated += TriggerNoWater;
    }

    private void TriggerNoEnergy()
    {
        if (energyTrigged)
        {
            return;
        }
        dialogueTriggerEnergy.TriggerDialogue();
        
        energyTrigged = true;

        if (energyTrigged && waterTrigged)
        {
            Destroy(this);
            Destroy(dialogueTriggerEnergy);
            Destroy(dialogueTriggerWater);
        }
    }
    private void TriggerNoWater()
    {
        if (waterTrigged)
        {
            return;
        }
        dialogueTriggerWater.TriggerDialogue();

        waterTrigged = true;

        if (energyTrigged && waterTrigged)
        {
            Destroy(this);
            Destroy(dialogueTriggerEnergy);
            Destroy(dialogueTriggerWater);
        }
    }
}
