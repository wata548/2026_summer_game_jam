using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace StatusEffect
{
	internal class SpikeShield : StatusEffectBase {
		public SpikeShield(int pAmount) : base(int.MaxValue) => 
			_amount = pAmount;
		
		private const float Term = 10;
		private const int DecreaseGuard = 5;
		private readonly int _amount;
		private float _timer;
		public override void StartEffect(IEntity pTarget) {
			pTarget.AddGuard(_amount);
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