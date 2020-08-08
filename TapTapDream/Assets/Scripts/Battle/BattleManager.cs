using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using static Battle.TypeSlider;
using Attribute = Battle.TypeSlider.Attribute;
using Random = UnityEngine.Random;

namespace Battle
{
    public class BattleManager : MonoBehaviour
    {
        [SerializeField] private Color FireColor = Color.red;
        [SerializeField] private Color WaterColor = Color.blue;
        [SerializeField] private Color WoodColor = Color.green;
        [SerializeField] private Color CureColor = Color.magenta;

        [SerializeField] private BattlePanel battlePanel = default;
        [SerializeField] private Tap[] taps;

        private static Enemy enemy = default;
        private static HitpointBar hitpointBar = default;

        private float hitpoint = 1000;
        private float bpm = 120.0f;
        private float power = 1.0f;

        private bool playBattle = true;

        private void Start()
        {
            enemy = GameObject.Find("Enemy").GetComponent<Enemy>();
            hitpointBar = gameObject.transform.Find("HitpointBar").GetComponent<HitpointBar>();

            enemy.Init(100, 30);

            hitpointBar.InitHitpoint(1000);
            taps = battlePanel.SetPanels(20);

            OnTypeSliderChanged();

            StartCoroutine(ActivateBattlePanel());
            StartCoroutine(EnemyActivateBattlePanel());
        }

        private IEnumerator ActivateBattlePanel()
        {
            int index = 0;
            int len = taps.Length;

            int[] rand = new int[len];

            for (int i = 0; i < len; i++)
                rand[i] = i;

            rand = rand.Shuffle().ToArray();

            float seconds = (60 / bpm);
            while (playBattle)
            {
                yield return new WaitForSeconds(seconds);
                taps[rand[index]].SetActive();
                index++;

                if (len <= index)
                {
                    index = 0;
                    rand = rand.Shuffle().ToArray();
                }
            }
        }

        private IEnumerator EnemyActivateBattlePanel()
        {
            float seconds = (60 / enemy.bpm);
            int index = 0;
            int len = taps.Length;
            while (playBattle)
            {
                yield return new WaitForSeconds(seconds);
                index = Random.Range(0, len);
                taps[index].SetEnemyAttack();
            }
        }

        public static void OnTapAction(bool playerAttack)
        {
            if (playerAttack)
                enemy.Damage(1);
            else
                hitpointBar.Damage(1);
        }

        public void OnTypeSliderChanged()
        {
            Attribute attribute = GetAttribute();
            Color color;

            switch (attribute)
            {
                case Attribute.FIRE: color = FireColor; break;
                case Attribute.WATER: color = WaterColor; break;
                case Attribute.WOOD: color = WoodColor; break;
                case Attribute.CURE: color = CureColor; break;
                default: color = Color.white; break;
            }

            for (int i = 0; i < taps.Length; i++)
                taps[i].SetTapColor(color);
        }
    }

    public static class IEnumerableExtension
    {
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> collection)
        {
            return collection.OrderBy(i => Guid.NewGuid());
        }
    }
}