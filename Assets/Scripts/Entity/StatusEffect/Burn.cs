using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StatusEffect
{
    internal class Burn : StatusEffectBase
    {
        public Burn(float pDuration, IEntity pTarget) : base(pDuration) {}
        private float _timer = 10;

        public override void StartEffect(IEntity pTarget)
        {
            pTarget.Attack.PowerMultiplier -= 0.1f;
        }
        public override void ExitEffect(IEntity pTarget)
        {
            pTarget.Attack.PowerMultiplier += 0.1f;
        }
    }
}
