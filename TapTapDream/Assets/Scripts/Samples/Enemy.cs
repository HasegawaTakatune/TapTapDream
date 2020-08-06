using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Sample
{
    public class Enemy : Character
    {
        public override void Init()
        {
            base.Init();
        }

        public override float Attack()
        {
            return base.Attack();
        }

        public override void Recovery(float value)
        {
            base.Recovery(value);
        }

        public override void Damage(float value, CharacterType type)
        {
            base.Damage(value, type);
        }

        public override void Dead()
        {
            base.Dead();
        }
    }
}