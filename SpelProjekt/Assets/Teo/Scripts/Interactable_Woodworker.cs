using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Interactable_Woodworker : Interactable
{
    public GameObject MonsterMenu;
    public Button button;
    public Image ProfilePic;
    public Sprite Sprite;
    public TextMeshProUGUI Nametext;
    public string Name;
    private WoodWorker w;
    private void Start()
    {
         w = GetComponent<WoodWorker>();
    }

    private void Update()
    {
        if (w.energy <= 0)
        {
            button.enabled = false;
        }
        else
        {
            button.enabled = true;
        }
    }

    public override void InteractWith(PlayerController pc)
    {
        if (isQuest)
        {
            base.InteractWith(pc);
            GetComponent<DialogueTrigger>().TriggerDialogue();
        }
        ProfilePic.sprite = Sprite;
        Nametext.text = Name;
        MonsterMenu.SetActive(true);
    }
}
