using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class BattlePanel : MonoBehaviour
    {
        private const int MAX_LENGTH = 20;

        [SerializeField] private GameObject content = default;
        [SerializeField] private GameObject prefab = default;

        public Tap[] SetPanels(int length)
        {
            if (MAX_LENGTH < length) length = MAX_LENGTH;

            Tap[] tap = new Tap[length];
            GameObject obj;

            for (int i = 0; i < length; i++)
            {
                obj = Instantiate(prefab, Vector3.zero, Quaternion.identity, content.transform);
                tap[i] = obj.GetComponent<Tap>();
            }

            return tap;
        }
    }
}