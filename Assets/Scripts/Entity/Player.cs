using System;
using Card.Inventory;
using Entity.AttackModule;
using Entity.AttackModule.Implements.Player;
using Extension;
using Extension.Test;
using Map;
using Movement;
using UnityEngine;

namespace Entity {
    public class Player: MonoSingleton<Player>, IEntity {
        //==================================================||Singleton Option 
        protected override bool IsNarrowSingleton => true;

        //==================================================||Events 
        public event Action<IEntity, int, bool> OnReceiveDamage;
        public event Action<IEntity, int> OnHeal;
        public event Action<IEntity> OnDeath;
        public event Action<IEntity, int> OnAddGuard;
        
        //==================================================||Properties 
        
        public readonly CardInventory CardInventory = new();

        public Vector3 Pos => transform.position;
        public IMovement Movement { get; private set; }
        public IAttack Attack { get; private set; }
        
        public bool IsInvincible { get; private set; } = false;
        public int MaxHp {
            get => _maxHp;
            set {
                if (value > 0) {
                    _maxHp += value;
                    Heal(value / 2);
                    return;
                }
                _maxHp -= value;
                Hp = Mathf.Min(Hp, MaxHp);
            }
        }
        public int Hp { get; private set; } = 100;
        public int Guard { get; private set; } = 0;

        public float DamageDownMultiplier {
            get => _damageDownMultiplier;
            set => _damageDownMultiplier = Mathf.Max(value, 0);
        }
        public int Power { get; private set; } = 20;
        
        public Vector2Int GridPos => new(
            Mathf.RoundToInt(transform.position.x / MapTile.Size),
            Mathf.RoundToInt(transform.position.y / MapTile.Size)
        );
        //==================================================||Fields 
        private int _maxHp = 100;
        private float _damageDownMultiplier = 1;
        
        //==================================================||Methods 
        public void ReceiveDamage(int pAmount) {

            if (IsInvincible) {
                OnReceiveDamage?.Invoke(this, 0, true);
                CardInventory.OnReceiveDamage(this, 0);
                return;
            }

            pAmount = Mathf.CeilToInt(pAmount * _damageDownMultiplier);
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
       private void Awake() {
           Cursor.lockState = CursorLockMode.Confined;
           Movement = new KeyboardMovement(5);
           Attack = new ProjectileAttack(this, 5, 15, 1, 0.3f, 30f);          
       }
       
       private void Update() {
           transform.position += Movement.GetDelta();
           CardInventory.Update(this);
           Attack.Update();
       }

       [TestMethod]
       private void ProjectileCntUp() {
           (Attack as IMultipleAttack)!.AttackCnt++;
       }
    }
}