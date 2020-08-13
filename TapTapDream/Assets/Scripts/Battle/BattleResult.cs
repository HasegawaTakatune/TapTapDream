using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Battle
{
    public class BattleResult : MonoBehaviour
    {
        [SerializeField] private Text result = default;

        public void ShowResult(string message)
        {
            gameObject.SetActive(true);
            result.text = message;
        }

        public void HideResult()
        {
            gameObject.SetActive(false);
        }
    }
}