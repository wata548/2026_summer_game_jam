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
            switch (Level)
            {
                case 0:

                    break;
            }
        }
    }
}
