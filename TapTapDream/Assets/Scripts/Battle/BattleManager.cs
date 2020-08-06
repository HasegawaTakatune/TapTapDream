using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static Battle.TypeSlider;

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

        private void Start()
        {
            enemy = GameObject.Find("Enemy").GetComponent<Enemy>();
            hitpointBar = gameObject.transform.Find("HitpointBar").GetComponent<HitpointBar>();

            hitpointBar.InitHitpoint(1000);
            taps = battlePanel.SetPanels(20);
        }

        void Update()
        {

        }

        public static void OnTapAction(bool playerAttack)
        {
            if (playerAttack)
                hitpointBar.Damage(1);
            else
                enemy.Damage(1);

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
}