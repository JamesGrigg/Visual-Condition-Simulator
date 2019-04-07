using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScripts : MonoBehaviour
{
    public Slider slider;
    public float time = 5f;

    void Start()
    {
        slider.maxValue = time;
        slider.minValue = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        slider.value = time;
    }
}
