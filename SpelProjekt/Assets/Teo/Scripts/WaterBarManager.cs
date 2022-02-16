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
    private int x = 0;
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
        Debug.Log(currentValue);
        Debug.Log(lastValue);
        t += lerpValue * Time.deltaTime;
        currentValue = player.waterAmount;
        
        DepleteWater(t);
    }

    private void DepleteWater(float time)
    {
        lastValue -= x;
        slider.value = Mathf.Lerp(lastValue, currentValue, time);
        x--;
    }
}
