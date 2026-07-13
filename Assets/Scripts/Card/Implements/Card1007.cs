using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Card
{
    class Card1007 : CoolTimeCard
    {
        public override float[] CoolTime => _coolTime;

        public override float[] Duration => _duration;
        private readonly float[] _coolTime = { 30, 25, 20 };
        private readonly float[] _duration = { 0, 0, 0 };

        private float timer;
        private bool IsReinforcing = false;
        private float[] AttackReinforce = { 0.2f, 0.25f };
        private float[] SpeedReinforce = { 0.05f, 0.1f };

        public override int Id => 1007;

        public override bool IsActive { protected set => throw new NotImplementedException(); }

        public override void EnterSkill(IEntity pTarget)
        {
            //주변 적 1 제거
            switch (Level)
            {
                case 1:
                    timer = 5;
                    pTarget.Attack.PowerMultiplier += AttackReinforce[Level - 1];
                    pTarget.Movement.SpeedMultiplier += SpeedReinforce[Level - 1];
                    IsReinforcing = true;
                    break;
                case 2:
                    timer = 5;
                    pTarget.Attack.PowerMultiplier += AttackReinforce[Level-1];
                    pTarget.Movement.SpeedMultiplier += SpeedReinforce[Level - 1];
                    IsReinforcing = true;
                    break;
            }
        }
        public override void Update(IEntity pTarget)
        {
            if (IsReinforcing==true)
            {
                timer -= Time.deltaTime;
                if (timer > 0) return;
                CancelEffect(pTarget);
                IsReinforcing=false;
            }
        }

        public void CancelEffect(IEntity pTarget) {
            if (IsReinforcing) {
                pTarget.Attack.PowerMultiplier -= AttackReinforce[Level - 1];
                pTarget.Movement.SpeedMultiplier -= SpeedReinforce[Level - 1];
            }
        } 

        public override void OnRemove(IEntity pTarget) {
            CancelEffect(pTarget);
        }
    }
}
//코드이따위로짜면안될것같은데 이거맞나...