using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using static Battle.TypeSlider;

namespace Battle
{
    public class Enemy : MonoBehaviour
    {
        public delegate void DEAD_CALLBACK(string message);
        private DEAD_CALLBACK deadCallback;
        public void AddDeadCallback(DEAD_CALLBACK callback) { deadCallback += callback; }
        public void RemoveDeadCallback(DEAD_CALLBACK callback) { deadCallback -= callback; }

        private const float EFFECTIVE = 1.5f;
        private const float NON_EFFECTIVE = 0.2f;

        private Attribute attribute;

        [SerializeField] private Slider hitpoint = default;
        [SerializeField] private Image image = default;

        public float bpm = 0;
        public float power = 1;

        public void Init(float hitpoint, float bpm, Attribute attribute)
        {
            this.hitpoint.maxValue = hitpoint;
            this.hitpoint.value = hitpoint;

            this.bpm = bpm;

            this.attribute = attribute;
        }

        public void Damage(float value, Attribute attack)
        {
            switch (attribute)
            {
                case Attribute.FIRE:
                    switch (attack)
                    {
                        case Attribute.WATER: value *= EFFECTIVE; break;
                        case Attribute.WOOD: value *= NON_EFFECTIVE; break;
                        default: break;
                    }
                    break;
                case Attribute.WATER:
                    switch (attack)
                    {
                        case Attribute.FIRE: value *= NON_EFFECTIVE; break;
                        case Attribute.WOOD: value *= EFFECTIVE; break;
                        default: break;
                    }
                    break;
                case Attribute.WOOD:
                    switch (attack)
                    {
                        case Attribute.FIRE: value *= EFFECTIVE; break;
                        case Attribute.WATER: value *= NON_EFFECTIVE; break;
                        default: break;
                    }
                    break;
                default: break;
            }

            hitpoint.value -= value;

            if (hitpoint.value <= 0)
                Dead();
        }

        private void Dead()
        {
            deadCallback?.Invoke("Win");
        }
    }
}