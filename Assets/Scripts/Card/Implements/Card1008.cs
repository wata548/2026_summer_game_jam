using Card;
using Entity;

namespace Card
{
    internal class Card1008 : CardBase
    {
        public override int Id => 1008;

        public override bool IsActive { get; protected set; } = true;

        public override void ApplyPassive(IEntity pTarget, bool pApply)
        {
            var symbol = pApply ? 1 : -1;
            switch (Level)
            {
                case 0:
                    pTarget.Attack.PowerMultiplier += 0.15f * symbol;
                    break;
                case 1:
                    pTarget.Attack.PowerMultiplier += 0.25f * symbol;
                    break;
                case 2:
                    pTarget.Attack.PowerMultiplier += 0.35f * symbol;
                    break;
            }
        }
    }
}
