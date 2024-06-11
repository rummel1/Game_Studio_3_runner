using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;
    public Gradient gradient;

    public Image fill;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetValue(int value)
    {
        slider.value = value;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    } 
    public void SetMinValue(int value)
    {
        slider.value = value;
        slider.minValue = value;
        fill.color= gradient.Evaluate(1f);
    }
}
