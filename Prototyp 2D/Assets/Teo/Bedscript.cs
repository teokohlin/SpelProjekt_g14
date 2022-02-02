using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bedscript : MonoBehaviour
{

    public UnityAction Slept;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Slept?.Invoke();
    }

}
