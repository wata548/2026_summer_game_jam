using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Card
{
    class Card1005 : CardBase
    {
        public override int Id => 1005;

        public override bool IsActive { get; protected set; } = true;
        public override void ApplyPassive(IEntity pTarget, bool pApply)
        {
            switch (Level)
            {
                case 0:
                    //칼날이돌아감(3개/15뎀)
                    break;
                case 1:
                    break;
                case 2:
                    break;
            }
                
            
        }
    }
}
