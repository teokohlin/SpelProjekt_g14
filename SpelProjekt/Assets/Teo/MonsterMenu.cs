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
    private float originalSizeHappiness;
    private int maxH = 10;
    void Start()
    {
        e = worker.Energy;
        maxE = e;
        originalSizeEnergy = EnergyBar.sizeDelta.x;
        originalSizeHappiness = HappinessBar.sizeDelta.x;
        rectSize = EnergyBar.sizeDelta;
        Picture.sprite = worker.ProfilePic;
        NameText.text = worker.Name;
    }

    // Update is called once per frame
    void Update()
    {
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
    }
}