namespace Entity.AttackModule {
    public interface IAttack {
        IEntity Owner { get; }
        int Power { get; }
        float PowerMultiplier { get; set;}
        void AddDefaultPower(int pPoint);
        void Update();
    }
}