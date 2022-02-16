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
    private float lerpValue = 0.1f;
    private float t;
    void Start()
    {
        slider.maxValue = player.maxWater;
        slider.value = slider.maxValue;
        lastValue = player.maxWater;
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        currentValue = player.waterAmount;
        if (currentValue < lastValue)
        {
            lastValue = currentValue;
            slider.value = Mathf.Lerp(lastValue, currentValue, lerpValue * Time.deltaTime);
        }
        //if current < last = lerp mellan last o current
       Debug.Log(currentValue);
       Debug.Log(lastValue);
    }

    private void DepleteWater(float time)
    {
        lastValue = currentValue;
        slider.value = Mathf.Lerp(lastValue, currentValue, lerpValue * time);
    }
}
