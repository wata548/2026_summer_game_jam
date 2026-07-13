using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;


namespace Card
{
    class Card1015 : CardBase
    {   
        public override int Id => 1015;

        public override bool IsActive { get; protected set; } = true;
        int randomNumber;
        public override void ApplyPassive(IEntity pTarget, bool pApply)
        {
            var symbol = pApply ? 1 : -1;

            switch (Level)
            {
                case 0:
                    randomNumber = UnityEngine.Random.Range(-5, 31);
                    pTarget.Attack.PowerMultiplier += 0.01f * randomNumber * symbol;
                    pTarget.Movement.SpeedMultiplier -= 0.15f * symbol;
                    break;
                case 1:
                    randomNumber = UnityEngine.Random.Range(0, 36);
                    pTarget.Attack.PowerMultiplier += 0.01f * randomNumber * symbol;
                    break;
                case 2:
                    randomNumber = UnityEngine.Random.Range(0, 41);
                    pTarget.Attack.PowerMultiplier += 0.01f * randomNumber * symbol;
                    break;
            }
        }
    }
}
