using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobbing : MonoBehaviour
{
    public float verticalBobFrequency = 1f;
    public float bobbingAmount = 1f;
    Vector3 startPosition;

    private void Start()
    {
        startPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    private void Update()
    {
        float bobbingAnimationPhase = ((Mathf.Sin(Time.time * verticalBobFrequency) * 0.5f) + 0.5f) * bobbingAmount;

        transform.position = startPosition + Vector3.up * bobbingAnimationPhase;
    }
}
