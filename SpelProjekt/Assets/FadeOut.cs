using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    [SerializeField]
    private float fadeMultiplier = 1f;

    private TextMeshProUGUI txt;
    void Start()
    {
        txt = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        //txt.color.a = Time.deltaTime * 0.1f;
        txt.alpha -= Time.deltaTime * fadeMultiplier;

        if (txt.alpha <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
