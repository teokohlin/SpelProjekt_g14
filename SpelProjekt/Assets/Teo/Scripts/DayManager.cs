using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DayManager : MonoBehaviour
{
    public TextMeshProUGUI text;
    public int currentDay = 0;
    public DayNightCycle Dnc;
    void Start()
    {
        Dnc.DayPast += ChangeDayText;
    }

    public void ChangeDayText(int day)
    {
        currentDay += day;
        text.text = "Day: " + currentDay.ToString();
    }
}
