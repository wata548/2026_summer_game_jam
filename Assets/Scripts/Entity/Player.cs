using System;
using Card.Inventory;
using Extension;
using Map;
using Movement;
using UnityEngine;

namespace Entity {
    public class Player: MonoSingleton<Player>, IEntity {
        //==================================================||Singleton Option 
        protected override bool IsNarrowSingleton => true;
        protected override bool AllowAutoGen => false;

        //==================================================||Events 
        public event Action<IEntity, int, bool> OnReceiveDamage;
        public event Action<IEntity, int> OnHeal;
        public event Action<IEntity> OnDeath;
        public event Action<IEntity, int> OnAddGuard;
        
        //==================================================||Properties 
        
        public readonly IMovement Movement = new KeyboardMovement();
        public readonly CardInventory CardInventory = new();

        public bool IsInvincible { get; private set; } = false;
        public int MaxHp { get; private set; } = 100;
        public int Hp { get; private set; } = 100;
        public int Guard { get; private set; } = 0;
        
        public Vector2Int GridPos => new(
            Mathf.RoundToInt(transform.position.x / MapTile.Size),
            Mathf.RoundToInt(transform.position.y / MapTile.Size)
        );
        //==================================================||Fields 
        [SerializeField] private float _speed = 3;
        
        //==================================================||Methods 
        public void ReceiveDamage(int pAmount) {

            if (IsInvincible) {
                OnReceiveDamage?.Invoke(this, 0, true);
                CardInventory.OnReceiveDamage(this, 0);
                return;
            }
            
            var guardApplied = false;
            var damage = pAmount;
            if (Guard > 0) {
                guardApplied = true;
                if (Guard >= pAmount)
                    Guard -= pAmount;
                else {
                    pAmount -= Guard;
                    Guard = 0;
                }
            }
            
            Hp = Mathf.Max(Hp - pAmount, 0);
            
            OnReceiveDamage?.Invoke(this, damage, guardApplied);
            CardInventory.OnReceiveDamage(this, pAmount);
            if (Hp <= 0) {
                CardInventory.OnDeath(this);
                //Card might recover player's hp
                if(Hp <= 0)
                    OnDeath?.Invoke(this);
            }
        }

        public void Heal(int pAmount) {
            Hp = Mathf.Min(Hp + pAmount, MaxHp);
            OnHeal?.Invoke(this, pAmount);
            CardInventory.OnHeal(this, pAmount);
        }

        public void AddGuard(int pAmount) {
            Guard += pAmount;
            OnAddGuard?.Invoke(this, pAmount);
            CardInventory.OnAddGuard(this, pAmount);
        }

        public void SetInvincible(bool pActive) => IsInvincible = pActive;
        
       //==================================================||Unity 
       private void Update() {
           transform.position += Movement.GetDirection() * (_speed * Time.deltaTime);
           CardInventory.Update(this);
       }
    }
}