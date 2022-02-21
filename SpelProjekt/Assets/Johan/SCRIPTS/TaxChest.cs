using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TaxChest : MonoBehaviour
{

    private Player player;

    public int woodNeeded = 50, stoneNeeded = 50, foodNeeded = 50;
    public TextMeshProUGUI woodText, stoneText, foodText;
    public GameObject woodButton, stoneButton, foodButton;
    private void Start()
    {
        player = FindObjectOfType<Player>();
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
        }
    }

    private void TryPayStone()
    {
        if (player.ReturnAmount(dType.stone) > stoneNeeded)
        {
            player.AddStone(-stoneNeeded);
            stoneButton.SetActive(stoneButton);
        }
    }

    private void TryPayFood()
    {
        if (player.ReturnAmount(dType.food) > foodNeeded)
        {
            player.AddFood(-foodNeeded);
            foodButton.SetActive(false);
        }
    }

    public void UpdateTaxChestTexts()
    {
        woodText.text = woodNeeded.ToString();
        stoneText.text = stoneNeeded.ToString();
        foodText.text = foodNeeded.ToString();
    }
}
