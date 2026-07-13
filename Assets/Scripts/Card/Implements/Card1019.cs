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
        private readonly int[] _maxHpDelta = { 50, 60, 70};
        private readonly float[] _coolTimeDelta = { 0.3f, 0.4f, 0.5f};


        public override int Id => 1019;

        public override bool IsActive { protected set => throw new NotImplementedException(); }
        public override void EnterSkill(IEntity pTarget)
        {
            Apply(pTarget, true);
        }

        private void Apply(IEntity pTarget, bool pApply)
        {
            var symbol = pApply ? 1 : -1;
            pTarget.MaxHp += _maxHpDelta[Level] * symbol;
            if (pTarget.Attack is ICoolTimeAttack attack) {
                attack.CoolTimeMultiplier -= _coolTimeDelta[Level] * symbol;
            }
        }
    }
}
