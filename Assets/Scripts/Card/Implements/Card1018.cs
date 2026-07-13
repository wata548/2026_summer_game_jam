using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Card
{
    class Card1018 : CoolTimeCard
    {
        public override float[] CoolTime => _coolTime;

		public override float[] Duration => _duration;
		private readonly float[] _coolTime = {20, 20, 20};
		private readonly float[] _duration = {10, 10, 10};
        private readonly float[] _powerDelta = { 0.4f, 0.45f, 0.55f};
        private readonly float[] _damageDelta = {0.2f, 0.25f, 0.3f};

        public override int Id => 1018;

        public override bool IsActive { protected set => throw new NotImplementedException(); }

        public override void EnterSkill(IEntity pTarget) {
            Apply(pTarget, true);
        }
        public override void ExitSkill(IEntity pTarget) {
            Apply(pTarget, false);
        }

        private void Apply(IEntity pTarget, bool pApply) {
            var symbol = pApply ? 1 : -1;
            pTarget.Attack.PowerMultiplier += _powerDelta[Level] * symbol;
            pTarget.DamageDownMultiplier += _damageDelta[Level] * symbol;
        }
    }
}
