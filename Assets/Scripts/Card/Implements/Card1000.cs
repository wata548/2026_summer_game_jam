using Card.Inventory;
using Entity;
using Entity.AttackModule;

namespace Card {
    public class Card1000: CardBase {
        public override int Id => 1000;
        public override bool IsActive { get; protected set; } = false;

        //TODO: Need to add on add card check
        public override void ApplyPassive(IEntity pTarget, bool pApply) {
            var symbol = pApply ? 1 : -1;
            switch (Level) {
                case 0:
                    pTarget.Attack.PowerMultiplier -= 0.05f * symbol;
                    break;
                case < 1:
                    if (pApply && Player.Instance.CardInventory.Cnt != 1)
                        break;
                    IsActive = true;
                    pTarget.Attack.PowerMultiplier += 0.25f * symbol;
                    if (pTarget.Attack is ICoolTimeAttack attack1)
                        attack1.CoolTimeMultiplier -= 0.1f * symbol;
                    break;
                case 2:
                    if (Player.Instance.CardInventory.Cnt != 1)
                        break;
                    IsActive = true;
                    pTarget.Attack.PowerMultiplier += 0.45f * symbol;
                    if (pTarget.Attack is ICoolTimeAttack attack2)
                        attack2.CoolTimeMultiplier -= 0.3f * symbol;
                    break;
            }
        }
    }
}