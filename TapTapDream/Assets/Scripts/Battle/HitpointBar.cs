using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Battle
{
    public class HitpointBar : MonoBehaviour
    {
        [SerializeField] private Slider HitpointSlider = default;
        [SerializeField] private Text HitpointText = default;

        public void InitHitpoint(float value)
        {
            HitpointSlider.maxValue = value;
            HitpointSlider.value = value;
            HitpointText.text = (int)value + " / " + (int)value;
        }

        public void Damage(float value)
        {
            HitpointSlider.value -= value;
            HitpointText.text = (int)HitpointSlider.maxValue + " / " + (int)HitpointSlider.value;
        }
    }
}