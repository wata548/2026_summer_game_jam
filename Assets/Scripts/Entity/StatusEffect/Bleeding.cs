using Entity;
using UnityEngine;

namespace StatusEffect {
	public class Bleeding: StatusEffectBase {
		public override int Id => 3001;
		public Bleeding(float pDuration) : base(pDuration) { }
		private const float DamageTerm = 3;
		private float _timer = DamageTerm;


		public override void StartEffect(IEntity pTarget) {
			pTarget.Movement.SpeedMultiplier -= 0.1f;
			_timer = DamageTerm;
		}

		public override void ExitEffect(IEntity pTarget) {
			pTarget.Movement.SpeedMultiplier += 0.1f;
		}

		protected override void UpdateEffect(IEntity pTarget) {
			_timer -= Time.deltaTime;
			if (_timer <= 0) {
				_timer = DamageTerm;
				pTarget.ReceiveDamage(5);
			}
		}
	}
}