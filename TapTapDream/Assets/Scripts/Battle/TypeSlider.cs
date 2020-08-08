using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Battle
{
    public class TypeSlider : MonoBehaviour
    {
        public enum Attribute { FIRE = 0, WATER, WOOD, CURE, LENGTH };
        private static Attribute attribute;

        private static Slider typeSlider = default;

        private void Awake()
        {
            typeSlider = GetComponent<Slider>();
        }

        public static Attribute GetAttribute()
        {
            int value = Mathf.FloorToInt(typeSlider.value);
            return (Attribute)value;
        }

        public void OnAttributeSliderEndDrag()
        {
            typeSlider.value = Mathf.Floor(typeSlider.value) + 0.5f;
        }
    }
}