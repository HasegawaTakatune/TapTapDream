using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapPanel : MonoBehaviour
{
    public bool isTap = true;

    public void OnTapPanel()
    {
        if (isTap)
        {
            GameManager.Score += 1;
            //isTap = false;
        }
    }
}
