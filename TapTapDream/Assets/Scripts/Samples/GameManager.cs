using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Sample
{
    public class GameManager : MonoBehaviour
    {
        private const int MAX_LENGTH = 20;

        [SerializeField] private GameObject content = default;
        [SerializeField] private GameObject prefab = default;

        private List<TapPanel> tapPanels = new List<TapPanel>();
        [SerializeField] private int[] random = { 0 };
        private int index = 0;

        private static float _attacked;
        public static float Score { get { return _attacked; } set { _attacked = value; } }

        private static Character enemy = new Character();

        private float _seconds = 1;
        public int BPM { set { _seconds = (60 / (float)value); } }

        [SerializeField] private Slider attackTypeSlider = default;
        public static Character.CharacterType characterType = Character.CharacterType.FIRE;

        private static Slider hitpointSlider = default;
        private static Text hitpointText = default;

        private static Player player = new Player();

        private void Start()
        {
            enemy = GameObject.Find("Orb").GetComponent<Character>();
            hitpointSlider = GameObject.Find("PlayerHitpoint").GetComponent<Slider>();
            hitpointText = GameObject.Find("PlayerHitpointText").GetComponent<Text>();

            Score = 0;

            BPM = 120;

            AddTapPanel(20);

            hitpointSlider.maxValue = player.maxHitpoint;

            StartCoroutine(GameLoop());
        }

        private void AddTapPanel(int value)
        {
            if (MAX_LENGTH < value) value = MAX_LENGTH;

            for (int i = tapPanels.Count; i < value; i++)
            {
                TapPanel obj = Instantiate(prefab, Vector3.zero, Quaternion.identity, content.transform).GetComponent<TapPanel>();
                tapPanels.Add(obj);
            }
            InitRandomArray();
        }

        private void InitRandomArray()
        {
            random = new int[tapPanels.Count];

            for (int i = 0; i < random.Length; i++)
                random[i] = i;

            random = random.Shuffle().ToArray();
        }

        private static void SetHitpointUI()
        {
            hitpointSlider.value = player.hitpoint;
            hitpointText.text = player.maxHitpoint + ":" + player.hitpoint;
        }

        private IEnumerator GameLoop()
        {
            float startFrame = Time.time;
            while (true)
            {
                yield return new WaitForSeconds(_seconds);

                tapPanels[random[index]].Active();
                index++;
                if (random.Length - 1 < index)
                {
                    random = random.Shuffle().ToArray();
                    index = 0;
                }
            }
        }

        public static void Tap(bool isTap)
        {
            if (!isTap)
            {
                player.hitpoint -= enemy.Attack();
                SetHitpointUI();
                return;
            }

            switch (characterType)
            {
                case Character.CharacterType.FIRE:
                case Character.CharacterType.WATER:
                case Character.CharacterType.GRASS:
                    enemy.Damage(player.power, characterType);
                    Debug.Log("Call");
                    break;

                case Character.CharacterType.RECOVERY:
                    player.hitpoint += player.recovery;
                    SetHitpointUI();
                    break;
            }
        }

        public void OnAttackTypeSliderEndDrag()
        {
            int type = Mathf.FloorToInt(attackTypeSlider.value);
            characterType = (Character.CharacterType)type;

            if (Mathf.FloorToInt(attackTypeSlider.maxValue) <= type)
                attackTypeSlider.value = attackTypeSlider.maxValue;
            else
                attackTypeSlider.value = type;
        }
    }

    public static class IEnumerableExtension
    {
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> collection)
        {
            return collection.OrderBy(i => Guid.NewGuid());
        }
    }

    public class Player
    {
        public float maxHitpoint = 1000;
        public float hitpoint = 1000;
        public float power = 1;
        public float speed = 120;
        public float lane = 20;
        public float recovery = 0.2f;
    }
}