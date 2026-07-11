using Entity;
using UnityEngine;

namespace Card {
    public abstract class CoolTimeCard: CardBase {
        public abstract float CoolTime { get; }
        public abstract float Duration { get; }
        public float CurTime { get; private set; }
        public bool InSkill { get; private set; } = true;

        public abstract void SkillImplement(IEntity pTarget);
        
        public sealed override void Update(IEntity pTarget) {
            CurTime += Time.deltaTime;
            if ((InSkill && CurTime >= Duration) || (!InSkill && CurTime >= CoolTime)) {
                CurTime = 0;
                InSkill = !InSkill;
            }
            if (InSkill) {
                SkillImplement(pTarget);
            }
        }
    }
}