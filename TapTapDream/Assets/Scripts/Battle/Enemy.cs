using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Slider hitpoint = default;

    private float attackSpeed = 0;

    public void Init(float hitpoint, float attackSpeed)
    {
        this.hitpoint.maxValue = hitpoint;
        this.hitpoint.value = hitpoint;

        this.attackSpeed = attackSpeed;
    }

    public void Damage(float value)
    {
        hitpoint.value -= value;
    }
}
