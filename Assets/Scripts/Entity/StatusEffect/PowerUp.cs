using Entity;

namespace StatusEffect {
	public class PowerUp:StatusEffectBase {
		public override int Id => 3006;
		private float _percent;

		public PowerUp(float pPercent, float pDuration) : base(pDuration) {
			_percent = pPercent;
		}

		public override void StartEffect(IEntity pTarget) {
			pTarget.Attack.PowerMultiplier += _percent;
		}

		public override void ExitEffect(IEntity pTarget) {
			pTarget.Attack.PowerMultiplier -= _percent;
		}
	}
}