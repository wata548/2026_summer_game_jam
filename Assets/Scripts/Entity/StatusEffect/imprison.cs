using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEditor.Rendering;

namespace StatusEffect
{
    internal class imprison : StatusEffectBase
    {
        float speed=0;
        public imprison(float pDuration) : base(pDuration){}
        public override void StartEffect(IEntity pTarget)
        {
            if (pTarget.Movement.SpeedMultiplier != 0)
            {
                speed = pTarget.Movement.SpeedMultiplier;
            }
            pTarget.Movement.SpeedMultiplier = 0;
        }

        public override void ExitEffect(IEntity pTarget)
        {
            if (speed!=0)
            {
                pTarget.Movement.SpeedMultiplier = speed;
            }
        }
    }
}
//속도가 이미 0일때는 안 걸리게