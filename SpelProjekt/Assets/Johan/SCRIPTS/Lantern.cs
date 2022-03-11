using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour
{
    public AnimationCurve lightIntensity;
    public Light light;
    public Light[] effectLights;
    private float OriginalIntensity;
    private float effectLightOrigIntensity;
    private DayNightCycle dnc;
    void Start()
    {
        dnc = FindObjectOfType<DayNightCycle>();

        OriginalIntensity = light.intensity;
        if (effectLights.Length > 0)
        {
            effectLightOrigIntensity = effectLights[0].intensity;
        }
    }

    void Update()
    {
        light.intensity = lightIntensity.Evaluate(dnc.time) * OriginalIntensity;
        foreach (var effectLight in effectLights)
        {
            effectLight.intensity = lightIntensity.Evaluate(dnc.time) * effectLightOrigIntensity;
        }
    }
}
