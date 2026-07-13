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
            switch (Level) {
                case 0:
                    pTarget.Attack.PowerMultiplier += 0.4f * symbol;
                    pTarget.DamageDownMultiplier += 0.2f * symbol;
                    break;
                case 1:
                    pTarget.Attack.PowerMultiplier += 0.45f * symbol;
                    pTarget.DamageDownMultiplier += 0.25f * symbol;
                    break;
                case 2:
                    pTarget.Attack.PowerMultiplier += 0.4f * symbol;
                    pTarget.DamageDownMultiplier += 0.2f * symbol;
                    break;
            }

        }
    }
}
