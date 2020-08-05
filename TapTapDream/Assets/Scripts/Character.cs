using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

[Serializable]
public class Character : MonoBehaviour
{
    private const float EFFECTIVE = 1.5f;
    private const float NON_EFFECTIVE = 0.2f;

    public enum CharacterType
    {
        FIRE = 0,
        WATER,
        GRASS
    }

    [SerializeField] private CharacterType charaType = CharacterType.FIRE;

    [SerializeField] protected Slider HitpointSlider = default;
    [SerializeField] protected float hitpoint = 100.0f;
    [SerializeField] protected float power = 1.0f;

    /// <summary>
    /// 閾値
    /// </summary>
    [SerializeField] protected float threshold = 3.5f;

    public bool isDead = false;

    private void Reset()
    {
        HitpointSlider = gameObject.GetComponentInChildren<Slider>();
    }

    public virtual void Init()
    {
        HitpointSlider.maxValue = hitpoint;
        HitpointSlider.value = hitpoint;
    }

    public virtual float Attack()
    {
        return Random.Range(power - threshold, power);
    }

    public virtual void Recovery(float value)
    {
        hitpoint += value;
    }

    public virtual void Damage(float value, CharacterType type)
    {
        if (isDead) return;

        float damage = 0;

        switch (type)
        {
            case CharacterType.FIRE:
                switch (charaType)
                {
                    case CharacterType.GRASS: damage = value * EFFECTIVE; break;
                    case CharacterType.WATER: damage = value * NON_EFFECTIVE; break;
                    default: damage = value; break;
                }
                break;
            case CharacterType.WATER:
                switch (charaType)
                {
                    case CharacterType.FIRE: damage = value * EFFECTIVE; break;
                    case CharacterType.GRASS: damage = value * NON_EFFECTIVE; break;
                    default: damage = value; break;
                }
                break;
            case CharacterType.GRASS:
                switch (charaType)
                {
                    case CharacterType.WATER: damage = value * EFFECTIVE; break;
                    case CharacterType.FIRE: damage = value * NON_EFFECTIVE; break;
                    default: damage = value; break;
                }
                break;
            default: break;
        }

        hitpoint -= damage;
        HitpointSlider.value = hitpoint;

        if (hitpoint <= 0) Dead();
    }

    public virtual void Dead()
    {
        isDead = true;
    }
}