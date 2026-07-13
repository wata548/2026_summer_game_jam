using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
namespace Card

{
    class Card1020 : CardBase
    {
        public override int Id => 1020;
        private bool IsRevival=false;
        private float timer;
        private float[] invincibleTimes = { 3, 5, 6 };
        private int[] heals = { 30, 60, 100 };

        public override bool IsActive { get; protected set; }=true;
        public override void OnDeath(IEntity pTarget)
        {

            pTarget.Heal(heals[Level]);
            IsActive = false;
            IsRevival = true;
            pTarget.IsInvincible = true;
            timer = invincibleTimes[Level];
        }
        public override void Update(IEntity pTarget)
        {
            if (IsRevival == true)
            {
                timer -= Time.deltaTime;
                if (timer <= 0) pTarget.IsInvincible = false;
            }
        }
    }
}
