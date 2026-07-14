using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace StatusEffect
{
	internal class SpikeShield : StatusEffectBase
	{
		public SpikeShield() : base(int.MaxValue) { }
		private const float Term = 10;
		private const int DecreaseGuard = 5;
		private float _timer;
		public override void StartEffect(IEntity pTarget) {
			_timer = Term;
		}

		protected override void UpdateEffect(IEntity pTarget)
		{
			_timer -= Time.deltaTime;
			if (_timer > 0) return;
				
			_timer = Term;
			var damage = DecreaseGuard;
			if (pTarget.Guard < DecreaseGuard)
				damage = pTarget.Guard;
			pTarget.ReceiveDamage(damage, true);
			
			if(pTarget.Guard <= 0) End();
		}
                
	}
}