using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Card
{
    class Card1012 : CardBase
    {
        public override int Id => 1012;

        public override bool IsActive { get; protected set; } = true;
        float timer;

        void update()
        {
            timer += Time.deltaTime;
        }
        public override void ApplyPassive(IEntity pTarget, bool pApply)
        {
            var symbol = pApply ? 1 : -1;

            switch (Level)
            {
                case 0:
                    if(timer%40 == 29)
                    {
                        pTarget.Movement.MoveFlip = true;
                        pTarget.MaxHp += 50;
                    }
                    if (timer % 40 == 39)
                    {
                        pTarget.Movement.MoveFlip = false;
                        pTarget.MaxHp -= 50;
                    }
                    
                    break;
                case 1:
                    pTarget.Attack.PowerMultiplier += 0.1f;
                    pTarget.MaxHp += 20;
                    break;
                case 2:
                    pTarget.Attack.PowerMultiplier += 0.15f;
                    pTarget.MaxHp += 30;
                    break;
            }
        }
    }
}
