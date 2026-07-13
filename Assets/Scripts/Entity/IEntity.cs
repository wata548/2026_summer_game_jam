using System;
using Entity.AttackModule;
using Movement;
using UnityEngine;

namespace Entity {
    public interface IEntity {
        event Action<IEntity, int, bool> OnReceiveDamage;
        event Action<IEntity> OnDeath;
        event Action<IEntity, int> OnHeal;
        public event Action<IEntity, int> OnAddGuard;
        
        Vector3 Pos{ get; }
        IMovement Movement{ get; }
        IAttack Attack { get; }
        bool IsInvincible{ get; set; }
        int MaxHp{ get; set; }
        int Hp{ get; }
        int Guard { get; }
        float DamageDownMultiplier { get; set; }
        
        void ReceiveDamage(int pAmount);
        void Heal(int pAmount);
        void AddGuard(int pAmount);
    }
}