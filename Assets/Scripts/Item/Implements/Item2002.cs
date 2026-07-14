using Entity;
using Item;
using StatusEffect;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assets.Scripts.Item.Implements
{
    internal class Item2002 : ItemBase
    {
        public override int Id => 2002;

        public override void Use()
        {
            Player.Instance.AddStatusEffect(new SpikeShield(50));
        }
    }
}