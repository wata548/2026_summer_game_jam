using Data;
using Entity;

namespace Card {
	public class Card1021: CardBase {
		public override int Id => 1021;
		public override bool IsActive { get; protected set; } = true;
		private float[] AttackMultiplier = { 0.4f, 0.7f, 1f };

		public override void ApplyPassive(IEntity pTarget, bool pApply) {
			pTarget.Attack.PowerMultiplier += AttackMultiplier[Level] * (pApply ? 1 : -1);
			if (!pApply) return;
			
			var commons = DataTables.Instance.CardDesc.Query(card => card.Rarity == Rarity.Common);
			foreach (var common in commons)
				Player.Instance.CardInventory.SetLevel(pTarget,common.Number, Level);
			if (Level == 0) return;
			
			var epics = DataTables.Instance.CardDesc.Query(card => card.Rarity == Rarity.Epic);
			foreach (var epic in epics)
				Player.Instance.CardInventory.SetLevel(pTarget,epic.Number, Level);
		}
	}
}