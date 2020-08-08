using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Battle
{
    public class Tap : MonoBehaviour
    {
        private const float WAIT_TIME = 1.0f;

        private Image TapPanel = default;
        private Color activeColor = Color.white;
        private Color enemyAttackColor = new Color(193, 0, 255);
        private bool isActive = false;
        private bool isEnemyAttack = false;

        private bool isWait = false;
        private float waitTimer = 0.0f;

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

            waitTimer = WAIT_TIME;
            if (!isWait)
                StartCoroutine(ResetActive());
        }

        public void SetEnemyAttack()
        {
            isActive = false;
            isEnemyAttack = true;
            TapPanel.color = enemyAttackColor;

            waitTimer = WAIT_TIME;
            if (!isWait)
                StartCoroutine(ResetActive());
        }

        private IEnumerator ResetActive()
        {
            isWait = true;
            while (0 < waitTimer)
            {
                yield return null;
                waitTimer -= Time.deltaTime;
            }
            isActive = false;
            isEnemyAttack = false;
            TapPanel.color = Color.white;
            isWait = false;
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