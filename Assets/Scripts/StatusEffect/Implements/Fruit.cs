using Entity;
using StatusEffect;
using System;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;

namespace StatusEffect
{
    internal class Fruit : StatusEffectBase
    {
        public override int Id => 3003;
        public Fruit(float pDuration) : base(pDuration) {}
        public override void StartEffect(IEntity pTarget)
        {
            pTarget.DamageDownMultiplier += 0.3f;
            pTarget.Movement.SpeedMultiplier -= 0.5f;
        }
        public override void ExitEffect(IEntity pTarget)
        {
            pTarget.DamageDownMultiplier -= 0.3f;
            pTarget.Movement.SpeedMultiplier += 0.5f;
        }
    }
}