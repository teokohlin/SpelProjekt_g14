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
        e = w.energy;
        originalSize = image.sizeDelta.x;
        rectSize = image.sizeDelta;
    }

    void Update()
    {
        if (e > w.energy)
        {
            image.sizeDelta -= new Vector2(originalSize / 3, 0);
            e = w.energy;
        }
        else if (e < w.energy)
        {
            image.sizeDelta = rectSize;
            e = w.energy;
        }
    }
}
