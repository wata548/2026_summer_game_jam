using Entity;
using StatusEffect;

namespace Item
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