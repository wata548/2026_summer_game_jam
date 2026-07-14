using Entity;
using Entity.AttackModule;
using System;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;

namespace Card
{
    class Card1006 : CardBase
    {
        public override int Id => 1006;

        public override bool IsActive { get; protected set; } = true;
        public override void ApplyPassive(IEntity pTarget, bool pApply)
        {
            var symbol = pApply ? 1 : -1;

            switch (Level)
            {
                case 0:
                    if (pTarget.Attack is IMultipleAttack attack0)
                    {
                        attack0.AttackCnt += 1 * symbol;
                    }
                    break;
                case 1:
                    if (pTarget.Attack is IMultipleAttack attack1)
                    {
                        attack1.AttackCnt += 2 * symbol;
                    }
                    break;
                case 2:
                    if (pTarget.Attack is IMultipleAttack attack2)
                    {
                        attack2.AttackCnt += 3 * symbol;
                    }
                    break;
            }
        }
    }
}
