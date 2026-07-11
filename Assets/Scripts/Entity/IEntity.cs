using System;
using UnityEngine;

namespace Entity {
    public interface IEntity {
        event Action<IEntity, int, bool> OnReceiveDamage;
        event Action<IEntity> OnDeath;
        event Action<IEntity, int> OnHeal;
        public event Action<IEntity, int> OnAddGuard;
        
        bool IsInvincible{ get; }
        int MaxHp{ get; }
        int Hp{ get; }
        int Guard { get; }
        void ReceiveDamage(int pAmount);
        void Heal(int pAmount);
        void AddGuard(int pAmount);
    }
}