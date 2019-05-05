using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScripts : MonoBehaviour
{
    public Slider slider;
    public float time;

    void Start()
    {
        time = 10f;
        slider.maxValue = time;
        slider.minValue = 0f;
    }

    public void Restart()
    {
        time = 10f;
        slider.value = time;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        slider.value = time;
    }
}
