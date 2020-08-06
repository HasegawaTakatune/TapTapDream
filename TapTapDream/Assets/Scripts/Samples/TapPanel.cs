using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Sample
{
    public class TapPanel : MonoBehaviour
    {
        [SerializeField] private Image image = default;
        private Color32 activeColor = new Color32(127, 255, 212, 255);

        private bool isTap = false;
        
        public void OnTapPanel()
        {
            if (isTap)
            {
                isTap = false;
                image.color = Color.white;
            }
            GameManager.Tap(isTap);
        }

        public void SetActiveColor(Color32 color)
        {
            activeColor = color;
            if (isTap)
                image.color = activeColor;
        }

        public void Active()
        {
            isTap = true;
            image.color = activeColor;
        }

    }
}
