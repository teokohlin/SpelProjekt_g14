using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResourceHandler : MonoBehaviour
{
    public Player player;

    public TextMeshProUGUI woodText;
    public TextMeshProUGUI stoneText;
    public TextMeshProUGUI foodText;
    [Space]
    public Image energyForeground;
    public Image energyBackground;
    public Sprite flashSprite;
    private Sprite bgOriginalSprite;

    bool eIconIsFlashing = false;
    void Start()
    {
        player = FindObjectOfType<Player>();
        
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
        if (eIconIsFlashing) //för att förhindra att den "spamblinkar"
        {
            return;
        }
        StartCoroutine(FlashCoroutine());
    }



    IEnumerator FlashCoroutine()
    {

        eIconIsFlashing = true;

        //Debug.Log("Started Coroutine at timestamp : " + Time.time);
        energyBackground.sprite = flashSprite;

        //yield on a new YieldInstruction that waits for .3f seconds.
        yield return new WaitForSeconds(.3f);

        energyBackground.sprite = bgOriginalSprite;


        yield return new WaitForSeconds(.3f);


        energyBackground.sprite = flashSprite;

        //yield on a new YieldInstruction that waits for 1 seconds.
        yield return new WaitForSeconds(.3f);

        energyBackground.sprite = bgOriginalSprite;
        //Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        yield return new WaitForSeconds(.3f);

        eIconIsFlashing = false;

    }

}
