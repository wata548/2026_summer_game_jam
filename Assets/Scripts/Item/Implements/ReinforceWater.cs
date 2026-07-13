using Entity;
using StatusEffect;

namespace Data.Item.Implements {
	public class ReinforceWater:ItemBase {
		public override int Id => 2005;
		public override void Use() =>
			Player.Instance.AddStatusEffectBase(new PowerUp(0.1f, 10));
	}
}