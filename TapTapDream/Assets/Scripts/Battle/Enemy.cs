using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Slider hitpoint = default;
    [SerializeField] private Image image = default;

    public float bpm = 0;
    public float power = 1;

    public void Init(float hitpoint, float bpm)
    {
        this.hitpoint.maxValue = hitpoint;
        this.hitpoint.value = hitpoint;

        this.bpm = bpm;
    }

    public void Damage(float value)
    {
        hitpoint.value -= value;
    }
}
