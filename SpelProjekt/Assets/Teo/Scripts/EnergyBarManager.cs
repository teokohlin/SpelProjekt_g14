using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBarManager : MonoBehaviour
{
    public RectTransform image;
    public WoodWorker w;
    private float originalSize;
    private Vector2 rectSize;
    private int e;
    void Start()
    {
        e = w.Energy;
        originalSize = image.sizeDelta.y;
        rectSize = image.sizeDelta;
    }

    void Update()
    {
        if (e > w.Energy)
        {
            image.sizeDelta -= new Vector2(0, originalSize / 3);
            e = w.Energy;
        }
        else if (e < w.Energy)
        {
            image.sizeDelta = rectSize;
            e = w.Energy;
        }
    }
}
