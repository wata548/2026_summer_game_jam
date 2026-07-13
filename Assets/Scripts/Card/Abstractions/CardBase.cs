using Data;
using Entity;

namespace Card {
    public abstract class CardBase {
       //==================================================||Properties 
        public abstract int Id { get; }
        public abstract bool IsActive { get; protected set; }
        public int Level { get; private set; } = 0;
        public bool LevelUpAble => Level < MaxLevel;
        public int MaxLevel => string.IsNullOrWhiteSpace(Desc.Level2Desc)
            ? string.IsNullOrWhiteSpace(Desc.Level1Desc)
                ? 0
                : 1
            : 2;
        
        public virtual bool RandomAppearAble => true;
        
        //==================================================||Fields 
        public readonly CardDesc Desc;

       //==================================================||Constructors 
        protected CardBase() {
            Desc = DataTables.Instance.CardDesc.Get(Id);
        }
        
        //==================================================||Methods 
        public void LevelUp(IEntity pTarget) {
            ApplyPassive(pTarget, false);
            Level++;
            ApplyPassive(pTarget, true);
        }

        public virtual void Update(IEntity pTarget) {}
        public virtual void ApplyPassive(IEntity pTarget, bool pApply) {}
        public virtual void OnDeath(IEntity pTarget) {}
        public virtual void OnReceiveDamage(IEntity pTarget, int pAmount) {}
        public virtual void OnHeal(IEntity pTarget, int pAmount) {}
        public virtual void OnAddGuard(IEntity pTarget, int pAmount) {}
        public virtual void OnAddCard(IEntity pTarget) {}
        public virtual void OnRemove(IEntity pTarget) {}
    }
}