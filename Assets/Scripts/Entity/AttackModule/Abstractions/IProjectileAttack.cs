namespace Entity.AttackModule {
    public interface IProjectileAttack {
        float Speed { get; }
        float SpeedMultiplier { get; set; }
    }
}