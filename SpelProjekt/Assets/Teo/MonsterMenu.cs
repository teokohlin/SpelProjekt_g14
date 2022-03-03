using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MonsterMenu : MonoBehaviour
{
    [Header("Worker Reference")]
    [SerializeField]
    private Worker worker;
    
    [Header("Profile")]
    [SerializeField]
    private Image Picture;
    
    [SerializeField] 
    private TextMeshProUGUI NameText;

    [Header("Energy")] 
    [SerializeField] 
    private RectTransform EnergyBar;
    private float originalSizeEnergy;
    private Vector2 rectSize;
    private int e;
    private int maxE;

    [Header("Happiness")]
    [SerializeField] 
    private RectTransform HappinessBar;
    [SerializeField] 
    private Gradient gradient;
    [SerializeField] 
    private Image HappinessImage;
    [SerializeField] 
    private Sprite[] sprites;
    private float originalSizeHappiness;
    private int maxH = 10;
    private Image fill;

    [Header("Buttons")][Tooltip("0 = Work")]
    [SerializeField] 
    private Button[] buttons;
    void Start()
    {
        e = worker.Energy;
        maxE = e;
        originalSizeEnergy = EnergyBar.sizeDelta.x;
        originalSizeHappiness = HappinessBar.sizeDelta.x;
        rectSize = EnergyBar.sizeDelta;
        Picture.sprite = worker.ProfilePic;
        NameText.text = worker.Name;
        fill = HappinessBar.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        fill.color = gradient.Evaluate(worker.Happiness);
        
        if (e > worker.Energy)
        {
            EnergyBar.sizeDelta -= new Vector2(originalSizeEnergy / maxE, 0);
            HappinessBar.sizeDelta -= new Vector2(originalSizeHappiness / maxH, 0);
            worker.Happiness -= 0.1f;
            e = worker.Energy;
        }
        else if (e < worker.Energy)
        {
            EnergyBar.sizeDelta = rectSize;
            e = worker.Energy;
        }
        if (worker.Energy <= 0)
        {
            buttons[0].enabled = false;
        }
        else
        {
            buttons[0].enabled = true;
        }

        switch (worker.Happiness)
        {
            case float f when f > 0.6f:
                ChangeHappinesSprite(0);
                break;
            case float f when f < 0.6f:
                ChangeHappinesSprite(1);
                break;
            case float f when f < 0.4f:
                ChangeHappinesSprite(2);
                break;
        }
    }

    private void ChangeHappinesSprite(int index)
    {
        for (int i = 0; i < sprites.Length; i++)
        {
            if (i == index)
            {
                HappinessImage.sprite = sprites[i];
            }
        }
    }
}