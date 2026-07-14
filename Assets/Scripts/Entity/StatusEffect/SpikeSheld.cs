using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace StatusEffect
{
    internal class SpikeSheld : StatusEffectBase
    {
        public SpikeSheld(float pDuration, IEntity pTarget) : base(pDuration) { }

        private float timer=10;
        private bool IsSheld; public override void StartEffect(IEntity pTarget)
        {
            if(pTarget.Guard>0) IsSheld= true;
        }

        public override void ExitEffect(IEntity pTarget)
        {
            base.ExitEffect(pTarget);
        }

        protected override void UpdateEffect(IEntity pTarget)
        {
            if (IsSheld)
            {
                timer-=Time.deltaTime;
                if (timer == 0)
                {
                    if (pTarget.Guard >= 5)
                    {
                        timer = 10;
                        pTarget.ReceiveDamage(Mathf.CeilToInt(5 / pTarget.DamageDownMultiplier));
                    }
                    else pTarget.ReceiveDamage(Mathf.CeilToInt(pTarget.Guard / pTarget.DamageDownMultiplier)); //5미만으로남았을때 남은만큼데미지
                    IsSheld = false;
                }
                
            }
        }
    }
}
