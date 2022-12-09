using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    

    public void Awake()
    {
       
    }


    public void SetMaxHealth(float time)
    {
        slider.maxValue = time;
        slider.value = time;
    }

    public void SetHealth(float time)
    {
        slider.value = time;
    }
}
