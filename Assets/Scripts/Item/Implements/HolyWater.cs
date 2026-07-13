using Entity;

namespace Data.Item.Implements {
	public class HolyWater: ItemBase {
		public override int Id => 2004;

		public override void Use() {
			Player.Instance.Heal(30);
		}
	}
}