using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Card
{
    class Card1018 : CoolTimeCard
    {
        public override float CoolTime => 20;

        public override float Duration => 10;

        public override int Id => 1018;

        public override bool IsActive { protected set => throw new NotImplementedException(); }

        public override void EnterSkill(IEntity pTarget)
        {
            switch (Level)
            {
                case 0:
                    pTarget.Attack.PowerMultiplier += 0.4f;
                    pTarget.DamageDownMultiplier += 0.2f;
                    break;
                case 1:
                    pTarget.Attack.PowerMultiplier += 0.45f;
                    pTarget.DamageDownMultiplier += 0.25f;
                    break;
                case 2:
                    pTarget.Attack.PowerMultiplier += 0.4f;
                    pTarget.DamageDownMultiplier += 0.2f;
                    break;
            }
            
        }
    }
}
