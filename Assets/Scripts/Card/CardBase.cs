using Data;
using Entity;

namespace Card {
    public abstract class CardBase {
       //==================================================||Properties 
        public abstract int Id { get; }
        public int Level { get; private set; } = 0;
        
        //==================================================||Fields 
        public readonly CardDesc Desc;

       //==================================================||Constructors 
        protected CardBase() {
            Desc = DataTables.Instance.CardDesc.Get(Id);
        }
        
        //==================================================||Methods 
        public void LevelUp() => Level++;

        public virtual void Update(IEntity pTarget) {}
        public virtual void OnGet(IEntity pTarget) {}
        public virtual void OnDeath(IEntity pTarget) {}
        public virtual void OnReceiveDamage(IEntity pTarget, int pAmount) {}
        public virtual void OnHeal(IEntity pTarget, int pAmount) {}
        public virtual void OnAddGuard(IEntity pTarget, int pAmount) {}
    }
}