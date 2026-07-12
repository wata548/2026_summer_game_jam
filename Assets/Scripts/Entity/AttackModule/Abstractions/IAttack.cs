namespace Entity.AttackModule {
    public interface IAttack {
        IEntity Owner { get; }
        int Power { get; }
        float PowerMultiplier { get; set;}
        void Update();
    }
}