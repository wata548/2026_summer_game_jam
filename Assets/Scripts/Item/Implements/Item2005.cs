using Entity;
using StatusEffect;

namespace Item {
	public class Item2005:ItemBase {
		public override int Id => 2005;
		public override void Use() =>
			Player.Instance.AddStatusEffect(new PowerUp(0.1f, 10));
	}
}