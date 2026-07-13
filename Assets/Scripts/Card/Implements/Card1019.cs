using Entity;
using Entity.AttackModule;
using System;
using System.Collections.Generic;
using System.Text;

namespace Card
{
    class Card1019 : CoolTimeCard
    {
        public override float[] CoolTime => _coolTime;

        public override float[] Duration => _duration;
        private readonly float[] _coolTime = { 20, 20, 20 };
        private readonly float[] _duration = { 10, 10, 10 };


        public override int Id => 1019;

        public override bool IsActive { protected set => throw new NotImplementedException(); }
        public override void EnterSkill(IEntity pTarget)
        {
            Apply(pTarget, true);
        }

        private void Apply(IEntity pTarget, bool pApply)
        {
            var symbol = pApply ? 1 : -1;
            switch (Level)
            {
                case 0:
                    pTarget.MaxHp += 50 * symbol;
                    if (pTarget.Attack is ICoolTimeAttack attack0)
                    {
                        attack0.CoolTimeMultiplier -= 0.3f * symbol;
                    }
                    break;
                case 1:
                    pTarget.MaxHp += 60 * symbol;
                    if (pTarget.Attack is ICoolTimeAttack attack1)
                    {
                        attack1.CoolTimeMultiplier -= 0.4f * symbol;
                    }
                    break;
                case 2:
                    pTarget.MaxHp += 70 * symbol;
                    if (pTarget.Attack is ICoolTimeAttack attack2)
                    {
                        attack2.CoolTimeMultiplier -= 0.5f * symbol;
                    }
                    break;
            }

        }
    }
}
