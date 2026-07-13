using System;
using System.Collections.Generic;
using Entity.AttackModule;
using Movement;
using StatusEffect;
using UnityEngine;

namespace Entity {
    public interface IEntity {
        event Action<IEntity, int, bool> OnReceiveDamage;
        event Action<IEntity> OnDeath;
        event Action<IEntity, int> OnHeal;
        event Action<IEntity> OnHpChange;
        event Action<IEntity, int> OnAddGuard;
        event Action<IEntity, bool> ChangeInvincibleValue;
        event Action<IEntity, Vector3> OnMove;
        
        Vector3 Pos{ get; }
        IMovement Movement{ get; }
        IAttack Attack { get; }
        IEnumerable<StatusEffectBase> StatusEffects { get; }
        bool IsInvincible{ get; set; }
        int MaxHp{ get; set; }
        int Hp{ get; }
        int Guard { get; }
        float DamageDownMultiplier { get; set; }
        
        void ReceiveDamage(int pAmount);
        void Heal(int pAmount);
        void AddGuard(int pAmount);

        void AddStatusEffectBase(StatusEffectBase pEffect);
    }
}