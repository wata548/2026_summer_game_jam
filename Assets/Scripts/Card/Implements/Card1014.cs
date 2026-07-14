using Entity;
using Entity.AttackModule;
using System;
using System.Collections.Generic;
using System.Text;

namespace Card
{
    internal class Card1014 : CardBase
    {
        public override int Id => 1014;

        public override bool IsActive { get; protected set; } = true;
        public override void ApplyPassive(IEntity pTarget, bool pApply)
        {
            var symbol = pApply ? 1 : -1;

            switch (Level)
            {
                case 0:
                    pTarget.Attack.PowerMultiplier += 0.05f * symbol;
                    pTarget.DamageDownMultiplier += 0.05f * symbol;
                    if(pTarget.Attack is ICoolTimeAttack attack0)
                    {
                        attack0.CoolTimeMultiplier -= 0.05f*symbol;
                    }
                    
                    break;
                case 1:
                    pTarget.Attack.PowerMultiplier += 0.1f * symbol;
                    pTarget.DamageDownMultiplier += 0.1f * symbol;
                    if (pTarget.Attack is ICoolTimeAttack attack1)
                    {
                        attack1.CoolTimeMultiplier -= 0.1f * symbol;
                    }
                    break;
                case 2:
                    pTarget.Attack.PowerMultiplier += 0.15f * symbol;
                    pTarget.DamageDownMultiplier += 0.15f * symbol;
                    if (pTarget.Attack is ICoolTimeAttack attack2)
                    {
                        attack2.CoolTimeMultiplier -= 0.15f * symbol;
                    }
                    break;
            }
        }
    }
}
