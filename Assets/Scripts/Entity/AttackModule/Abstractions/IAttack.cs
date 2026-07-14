using System;

namespace Entity.AttackModule {
    public interface IAttack {
        public event Action OnAttack;
        public event Action CoolDownAnimation;
        IEntity Owner { get; }
        int Power { get; }
        float PowerMultiplier { get; set;}
        void AddDefaultPower(int pPoint);
        void Update();
    }
}