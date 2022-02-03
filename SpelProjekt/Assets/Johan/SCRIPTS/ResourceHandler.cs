using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceHandler : MonoBehaviour
{
    public Player player;

    public Text woodText;
    public Text stoneText;
    public Text foodText;
    void Start()
    {
        player.woodUpdate += WoodTextUpdate;
        player.stoneUpdate += StoneTextUpdate;
        player.foodUpdate += FoodTextUpdate;
    }



    void WoodTextUpdate(int amount)
    {
        woodText.text = amount.ToString();
    }
    void StoneTextUpdate(int amount)
    {
        stoneText.text = amount.ToString();
    }
    void FoodTextUpdate(int amount)
    {
        foodText.text = amount.ToString();
    }

}
