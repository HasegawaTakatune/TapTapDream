using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Battle
{
    public class HitpointBar : MonoBehaviour
    {
        public delegate void DEAD_CALLBACK(string message);
        private DEAD_CALLBACK deadCallback;
        public void AddDeadCallback(DEAD_CALLBACK callback) { deadCallback += callback; }
        public void RemoveDeadCallback(DEAD_CALLBACK callback) { deadCallback -= callback; }

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

            if (HitpointSlider.value <= 0)
                Dead();
        }

        public void Cure(float value)
        {
            HitpointSlider.value += value;
            HitpointText.text = (int)HitpointSlider.maxValue + " / " + (int)HitpointSlider.value;
        }

        private void Dead()
        {
            deadCallback?.Invoke("Lose");
        }
    }
}