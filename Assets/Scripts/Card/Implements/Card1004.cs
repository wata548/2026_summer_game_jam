using Entity;
using Entity.AttackModule;
using System;
using System.Collections.Generic;
using System.Text;

namespace Card
{
    class Card1004 : CoolTimeCard
    {
        public override float[] CoolTime => _coolTime;

        public override float[] Duration => _duration;
        private readonly float[] _coolTime = { 20, 20, 20 };
        private readonly float[] _duration = { 0, 0, 0 };

        public override int Id => 1004;

        public override bool IsActive { protected set => throw new NotImplementedException(); }

        public override void EnterSkill(IEntity pTarget)
        {
            Apply(pTarget, true);
        }
        public override void ExitSkill(IEntity pTarget)
        {
            Apply(pTarget, false);
        }

        private void Apply(IEntity pTarget, bool pApply)
        {
            var symbol = pApply ? 1 : -1;
            switch (Level)
            {
                case 0:
                    //구속
                    //적데미지
                    break;
                case 1:
                    //구속
                    //적데미지
                    break;
                case 2:
                    //구속
                    //적데미지
                    break;
            }

        }
        public override void OnRemove(IEntity pTarget)
        {
            ExitSkill(pTarget);
        }
    }
}
