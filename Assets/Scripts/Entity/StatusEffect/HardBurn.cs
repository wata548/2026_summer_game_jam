using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace StatusEffect
{
    internal class HardBurn : StatusEffectBase
    {

        private float timer;
        private bool IsSheld;
        public HardBurn(float pDuration, IEntity pTarget) : base(pDuration) { }
        public override void StartEffect(IEntity pTarget)
        {
            pTarget.Attack.PowerMultiplier -= 0.4f;
        }

        public override void ExitEffect(IEntity pTarget)
        {
            pTarget.Attack.PowerMultiplier -= 0.4f;
        }
    }
}
