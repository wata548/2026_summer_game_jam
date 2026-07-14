using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Card
{
    internal class Card1003 : CoolTimeCard
    {
        public override float[] CoolTime => _coolTime;

        public override float[] Duration => _duration;
        private readonly float[] _coolTime = { 30, 20, 20 };
        private readonly float[] _duration = { 5, 6, 10 };
        public override int Id => 1003;

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
                    //장판
                    break;
                case 1:
                    break;
                case 2:
                    break;
            }

        }
        public override void OnRemove(IEntity pTarget)
        {
            ExitSkill(pTarget);
        }
    }
}
