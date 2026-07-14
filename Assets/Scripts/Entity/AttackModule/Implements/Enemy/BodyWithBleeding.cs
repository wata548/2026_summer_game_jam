using StatusEffect;

namespace Entity.AttackModule.Implements.Player {
	public class BodyWithBleeding: Body {
		public BodyWithBleeding(IEntity pOwner, int pPower) : base(pOwner, pPower) { }
		public override void OnAttacked(IEntity pTarget) {
			pTarget.AddStatusEffect(new Bleeding(3));
		}
	}
}