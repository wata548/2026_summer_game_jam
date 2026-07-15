using System.Linq;
using Entity;

namespace Card {
	public class Card1013: CardBase {
		public override int Id => 1013;
		public override bool IsActive { get; protected set; }

		public override void ApplyPassive(IEntity pTarget, bool pApply) {
			if (!pApply) return;
			var amount = Player.Instance.CardInventory.Cards.Count();
			foreach (var card in Player.Instance.CardInventory.Cards.ToList()) {
				Player.Instance.CardInventory.Remove(pTarget, card.Id);
			}
			pTarget.MaxHp += (amount + 1) * 15;
		}

		public override void Update(IEntity pTarget) {
			Player.Instance.CardInventory.Remove(pTarget, Id);
		}
	}
}