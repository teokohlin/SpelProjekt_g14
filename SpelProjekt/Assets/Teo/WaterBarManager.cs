using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterBarManager : MonoBehaviour
{
    public Slider slider;
    public Player player;
    private float currentValue;
    private float lastValue;
    void Start()
    {
        player.waterUpdate += DepleteWater;
        slider.maxValue = player.maxWater;
        lastValue = player.maxWater;
    }

    // Update is called once per frame
    void Update()
    {
        currentValue = player.waterAmount;
        //if current < last = lerp mellan last o current
       
    }

    private void DepleteWater(float f)
    {
        lastValue = currentValue;
        slider.value = Mathf.Lerp(lastValue, f, Time.deltaTime);
    }
}
