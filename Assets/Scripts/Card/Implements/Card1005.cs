using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

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
                    Player.Instance.Skill.Knife.Set(3, 10);
                    break;
                case 1:
                    Player.Instance.Skill.Knife.Set(4, 15);
                    break;
                    break;
                case 2:
                    Player.Instance.Skill.Knife.Set(5, 15);
                    break;
            }
                
            
        }
    }
}
