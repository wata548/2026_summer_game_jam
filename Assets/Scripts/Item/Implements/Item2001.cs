using Entity;
using StatusEffect;
using System;
using System.Collections.Generic;
using System.Text;

namespace Item
{
    internal class Item2001 : ItemBase
    {
        public override int Id => 2001;
        
        public override void Use()
        {
            Player.Instance.Heal(30);
            Player.Instance.AddStatusEffect(new DamageDown(0.2f, 10));
        }
    }
}