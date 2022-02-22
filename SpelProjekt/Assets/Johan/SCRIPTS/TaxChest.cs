using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TaxChest : MonoBehaviour
{

    private Player player;

    public int woodNeeded = 50, stoneNeeded = 50, foodNeeded = 50;
    public TextMeshProUGUI woodText, stoneText, foodText;
    public GameObject woodButton, stoneButton, foodButton;
    public bool woodPayed, stonePayed, foodPayed;

    public UnityAction taxNotPaid;
    public UnityAction taxPaid;


    private int weekday;
    private void Start()
    {
        player = FindObjectOfType<Player>();
        //prenumerera "newday" p� daymanager
    }

    public void ButtonClicked(int type)
    {
        switch (type)       
        {
            case 0:
                TryPayWood();
                break;
            case 1:
                TryPayStone();
                break;
            case 2:
                TryPayFood();
                break;
            default:
                break;
        }
    }

    private void TryPayWood()
    {
        if (player.ReturnAmount(dType.wood) > woodNeeded)
        {
            player.AddWood(-woodNeeded);
            woodButton.SetActive(false);
            woodPayed = true;
        }
    }

    private void TryPayStone()
    {
        if (player.ReturnAmount(dType.stone) > stoneNeeded)
        {
            player.AddStone(-stoneNeeded);
            stoneButton.SetActive(stoneButton);
            stonePayed = true;
        }
    }

    private void TryPayFood()
    {
        if (player.ReturnAmount(dType.food) > foodNeeded)
        {
            player.AddFood(-foodNeeded);
            foodButton.SetActive(false);
            stonePayed = true;
        }
    }

    public void UpdateTaxChestTexts()
    {
        woodText.text = woodNeeded.ToString();
        stoneText.text = stoneNeeded.ToString();
        foodText.text = foodNeeded.ToString();
    }

    public void NewDay() //prenumerera p� nydag unity action fr�n daymanager
    {
        weekday++;
        if (weekday >= 7)
        {
            if (woodPayed && stonePayed && foodPayed)
            {
                taxPaid?.Invoke();
            }
            else
            {
                taxNotPaid?.Invoke();
            }

            weekday = 1;
            woodPayed = false; stonePayed = false; foodPayed = false;
            woodButton.SetActive(true); stoneButton.SetActive(true); foodButton.SetActive(true);

        }
    }
}
