namespace Entity.AttackModule {
    public interface ICoolTimeAttack {
        float CoolTime { get; }
        float CoolTimeMultiplier { get; set; }
    }
}