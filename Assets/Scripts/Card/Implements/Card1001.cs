using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Card
{
    internal class Card1001 : CardBase
    {
        public override int Id => 1001;

        public override bool IsActive { get; protected set; } = true;

        public override void ApplyPassive(IEntity pTarget, bool pApply)
        {
            switch (Level)
            {
                case 0:
                    pTarget.Attack.PowerMultiplier += 0.05f;
                    pTarget.MaxHp += 15;
                    break;
                case 1:
                    pTarget.Attack.PowerMultiplier += 0.1f;
                    pTarget.MaxHp += 20;
                    break;
                case 2:
                    pTarget.Attack.PowerMultiplier += 0.15f;
                    pTarget.MaxHp += 30;
                    break;
            }
        }
    }
}
