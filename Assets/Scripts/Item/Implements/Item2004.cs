using Entity;

namespace Item {
	public class Item2004: ItemBase {
		public override int Id => 2004;

		public override void Use() {
			Player.Instance.Heal(30);
		}
	}
}