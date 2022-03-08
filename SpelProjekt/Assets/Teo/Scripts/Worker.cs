using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : MonoBehaviour
{
    public Sprite ProfilePic;
    public string Name;

    [SerializeField] 
    protected int MaxEnergy;

    [HideInInspector] public int Energy;
    
    [Range(0,1)]
    public float Happiness;

    private void Awake()
    {
        Energy = MaxEnergy;
    }
}
