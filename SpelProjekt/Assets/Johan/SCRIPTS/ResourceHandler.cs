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
    [Space]
    public Image energyForeground;
    public Image energyBackground;
    public Sprite flashSprite;
    private Sprite bgOriginalSprite;
    void Start()
    {
        player.woodUpdate += WoodTextUpdate;
        player.stoneUpdate += StoneTextUpdate;
        player.foodUpdate += FoodTextUpdate;
        player.energyPercentageUpdate += EnergyImageUpdate;
        player.noEnergyActivated += EnergyIconFlash;

        bgOriginalSprite = energyBackground.sprite;
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
    void EnergyImageUpdate(float percentage)
    {
        energyForeground.fillAmount = percentage;
    }

    void EnergyIconFlash()
    {
        StartCoroutine(ExampleCoroutine());
        Debug.Log("d");
    }



    IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        energyBackground.sprite = flashSprite;

        //yield on a new YieldInstruction that waits for 1 seconds.
        yield return new WaitForSeconds(.3f);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        energyBackground.sprite = bgOriginalSprite;


        yield return new WaitForSeconds(.3f);


        energyBackground.sprite = flashSprite;

        //yield on a new YieldInstruction that waits for 1 seconds.
        yield return new WaitForSeconds(.3f);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        energyBackground.sprite = bgOriginalSprite;

    }

}
