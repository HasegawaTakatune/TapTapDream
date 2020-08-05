using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapPanel : MonoBehaviour
{
    [SerializeField]private Image image = default;
    private Color32 activeColor = new Color32(127,255,212,255);

    public bool isTap = false;

    public void OnTapPanel()
    {
        if (isTap)
        {
            GameManager.Score += 1;
            isTap = false;
            image.color = Color.white;
        }
    }

    public void Active()
    {
        isTap = true;
        image.color = activeColor;
    }
}
