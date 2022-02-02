using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour
{
    public Text wood, stone, iron, food;
    private int wR, sR, iR, fR;
    public RectTransform energiIcon;
    public GameObject infotext;
    private float originalSx;
    private float originalSy;
    public TreeScript[] träd;
    public RockScript[] rocks;
    public CanvasButtons canvas;
    public PlayerScript player;
    private float timer;
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerScript>();
        player.RefillEnergy += AddenergiIcon;
        originalSx = energiIcon.sizeDelta.x;
        originalSy = energiIcon.sizeDelta.y;
        canvas.Useenergi += RemoveEnergiIcon;
        canvas.AddFood += FoodResource;
        foreach (var t in träd)
        {
            t.UseEnergi += RemoveEnergiIcon;
        }
        foreach (var t in träd)
        {
            t.AddWood += WoodResource;
        }
        foreach (var rock in rocks)
        {
            rock.UseEnergy += RemoveEnergiIcon;
        }
        foreach (var rock in rocks)
        {
            rock.AddStone += StoneResource;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player.energi <= 0)
        {
            infotext.SetActive(true);
        }
        else if (player.energi > 0)
            infotext.SetActive(false); 
        
    }

    public void WoodResource(int w)
    {
        wR += w;
        wood.text = wR.ToString();
    }

    void StoneResource(int s)
    {
        sR += s;
        stone.text = sR.ToString();
    }
    void FoodResource(int f)
    {
        fR += f;
        food.text = fR.ToString();
    }
    
    
     public void AddenergiIcon()
    {
        energiIcon.sizeDelta = new Vector2(originalSx, originalSy);
    }
     public void RemoveEnergiIcon()
    {
        energiIcon.sizeDelta -= new Vector2(originalSx / 3, 0);
    }
}
