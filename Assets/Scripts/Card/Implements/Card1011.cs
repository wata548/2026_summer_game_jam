using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Card
{
    internal class Card1011 : CardBase
    {
        public override int Id => 1011;

        public override bool IsActive { get; protected set; } = true;

        public override void ApplyPassive(IEntity pTarget, bool pApply)
        {
            var symbol = pApply ? 1 : -1;
            switch (Level)
            {
                case 0:
                    pTarget.Attack.PowerMultiplier += 0.2f * symbol    ;
                    pTarget.MaxHp -= 25*symbol;
                    break;
                case 1:
                    pTarget.Attack.PowerMultiplier += 0.3f * symbol;
                    pTarget.MaxHp -= 20*symbol;
                    break;
                case 2:
                    pTarget.Attack.PowerMultiplier += 0.4f * symbol;
                    pTarget.MaxHp -= 15*symbol;
                    break;
            }
        }
    }
}
