using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Card {
	internal class Card1002 : CardBase {
		public override int Id => 1002;

		public override bool IsActive { get; protected set; } = true;

        private float timer;
        private int[] heals = { 0, 3, 5 };
        private bool IsHealing = false;
        

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
                    break;
                case 2:
                    pTarget.DamageDownMultiplier += 0.1f * symbol;
                    break;
            }
        }
        
        public override void Update(IEntity pTarget)
        {
            if (IsHealing == true)
            {
                timer += Time.deltaTime;
                if(timer % 5 == 0) OnHeal(pTarget, heals[Level]);
            }
            
        }
    }
}
