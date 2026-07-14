using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEditor.Rendering;

namespace StatusEffect
{
    internal class Imprison : StatusEffectBase
    {
        public override int Id => 3005;
        public Imprison(float pDuration) : base(pDuration){}
        public override void StartEffect(IEntity pTarget) {
            pTarget.Movement.MoveLock = true;
        }

        public override void ExitEffect(IEntity pTarget) {
            pTarget.Movement.MoveLock = false;
        }
    }
}