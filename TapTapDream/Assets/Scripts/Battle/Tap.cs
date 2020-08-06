using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Battle
{
    public class Tap : MonoBehaviour
    {
        private Image TapPanel = default;
        private Color activeColor = Color.white;
        private Color enemyAttackColor = new Color(193, 0, 255);
        private bool isActive = false;
        private bool isEnemyAttack = false;

        private void Start()
        {
            TapPanel = GetComponent<Image>();
        }

        public void SetTapColor(Color color)
        {
            activeColor = color;
            if (isActive)
                TapPanel.color = color;
        }

        public void SetActive()
        {
            isActive = true;
            isEnemyAttack = false;
            TapPanel.color = activeColor;
        }

        public void SetEnemyAttack()
        {
            isActive = false;
            isEnemyAttack = true;
            TapPanel.color = enemyAttackColor;
        }

        public void OnTapPanel()
        {
            if (isActive)
                BattleManager.OnTapAction(true);
            else if (isEnemyAttack)
                BattleManager.OnTapAction(false);

            isActive = false;
            isEnemyAttack = false;
            TapPanel.color = Color.white;
        }
    }
}