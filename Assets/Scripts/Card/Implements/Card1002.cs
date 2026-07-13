using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Card {
	internal class Card1002 : CardBase {
		public override int Id => 1002;

		public override bool IsActive { get; protected set; } = true;
        public override void ApplyPassive(IEntity pTarget, bool pApply)
        {
            var symbol = pApply ? 1 : -1;

            switch (Level)
            {
                case 0:
                    pTarget.DamageDownMultiplier += 0.1f * symbol;
                    break;
                case 1:
                    pTarget.DamageDownMultiplier += 0.1f * symbol;
                    //초당 3씩 회복
                    break;
                case 2:
                    pTarget.DamageDownMultiplier += 0.1f * symbol;
                    break;
            }
        }
    }
}
