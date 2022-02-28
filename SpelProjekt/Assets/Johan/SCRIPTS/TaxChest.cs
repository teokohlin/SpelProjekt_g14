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
    private bool woodPayed, stonePayed, foodPayed;
    public int daysBetweenTax = 14;

    private DayNightCycle dnc;

    public UnityAction taxNotPaid;
    public UnityAction taxPaid;


    private int weekday;
    private void Start()
    {
        player = FindObjectOfType<Player>();
        dnc = FindObjectOfType<DayNightCycle>();
        dnc.DayPast += NewDay;  //prenumerera "newday" på daymanager

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
        if (player.ReturnAmount(dType.wood) >= woodNeeded)
        {
            player.AddWood(-woodNeeded);
            woodButton.SetActive(false);
            woodPayed = true;
        }
    }

    private void TryPayStone()
    {
        if (player.ReturnAmount(dType.stone) >= stoneNeeded)
        {
            player.AddStone(-stoneNeeded);
            stoneButton.SetActive(false);
            stonePayed = true;
        }
    }

    private void TryPayFood()
    {
        if (player.ReturnAmount(dType.food) >= foodNeeded)
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

    public void NewDay() //prenumerera på nydag unity action från daymanager
    {
        weekday ++;
        if (weekday >= daysBetweenTax)
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
