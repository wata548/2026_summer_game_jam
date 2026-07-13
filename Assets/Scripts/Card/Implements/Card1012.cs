using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Card
{
    class Card1012 : CoolTimeCard
    {
        public override bool IsActive { protected set => throw new NotImplementedException(); }
        public override float CoolTime => 30;

        public override float Duration => 10;

        public override int Id => 1012;

        public override void EnterSkill(IEntity pTarget)
        {
            switch (Level)
            {
                case 0:
                    pTarget.Movement.MoveFlip = true;
                    pTarget.MaxHp += 50;
                    break;
                case 1:
                    pTarget.Movement.MoveFlip = true;
                    pTarget.MaxHp += 50;
                    break;
                case 2:
                    pTarget.Movement.MoveFlip = true;
                    pTarget.MaxHp += 50;
                    break;
            }
        }
        public override void ExitSkill(IEntity pTarget)
        {

            switch (Level)
            {
                case 0:
                    pTarget.Movement.MoveFlip = true;
                    pTarget.MaxHp -= 50;
                    break;
                case 1:
                    pTarget.Movement.MoveFlip = true;
                    pTarget.MaxHp += 50;
                    break;
                case 2:
                    pTarget.Movement.MoveFlip = true;
                    pTarget.MaxHp += 50;
                    break;
            }
        }

    }
}
