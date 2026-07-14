using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StatusEffect
{
    public class DamageDown: StatusEffectBase
    {
        private float _percent;
        public DamageDown(float pPercent, float pDuration) : base(pDuration)
        {
            _percent = pPercent;
        }

        public override int Id => 3008;

        public override void StartEffect(IEntity pTarget)
        {
            pTarget.DamageDownMultiplier += _percent;
        }
        public override void ExitEffect(IEntity pTarget)
        {
            pTarget.DamageDownMultiplier -= _percent;
        }
    }
}
