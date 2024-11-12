using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Slider healthSlider;

    public void SetMaxHealth(int health)
    {
        healthSlider.maxValue = health;
        healthSlider.value = health;

        //Debug.Log($"{healthSlider.value} / {healthSlider.maxValue}");
    }
    public void updateHealthBar(int health)
    {
        healthSlider.value = health;
        //healthSlider.maxValue = health;
    }
}
