using Entity;

namespace StatusEffect
{
    internal class HardBurn : StatusEffectBase
    {
        public override int Id => 3004;
        public HardBurn(float pDuration) : base(pDuration) { }
        public override void StartEffect(IEntity pTarget)
        {
            pTarget.Attack.PowerMultiplier -= 0.4f;
        }

        public override void ExitEffect(IEntity pTarget)
        {
            pTarget.Attack.PowerMultiplier -= 0.4f;
        }
    }
}
