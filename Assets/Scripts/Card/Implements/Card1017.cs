using Card;
using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Card
{
    class Card1017 : CardBase
    {
        public override int Id => 1017;

        public override bool IsActive { get; protected set; } = true;

        public override void ApplyPassive(IEntity pTarget, bool pApply)
        {
            var symbol = pApply ? 1 : -1;

            switch (Level)
            {
                case 0:
                    pTarget.Movement.SpeedMultiplier += 0.1f * symbol;
                    break;
                case 1:
                    Player.Instance.ItemInventory.AddInventorySize(1);
                    pTarget.Attack.PowerMultiplier += 0.25f * symbol;
                    break;
                case 2:
                    Player.Instance.ItemInventory.AddInventorySize(2);
                    pTarget.Attack.PowerMultiplier += 0.35f * symbol;
                    break;
            }
        }
    }
}
