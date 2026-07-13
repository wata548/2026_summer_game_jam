using System;
using System.Collections.Generic;
using System.Linq;
using Card.Inventory;
using Data.Level;
using Entity.AttackModule;
using Entity.AttackModule.Implements.Player;
using Extension;
using Extension.Test;
using Map;
using Movement;
using StatusEffect;
using UnityEngine;

namespace Entity {
	
	public class Player: MonoSingleton<Player>, IEntity {
		//==================================================||Singleton Option 
		protected override bool IsNarrowSingleton => true;

		//==================================================||Events 
		public event Action<IEntity, int, bool> OnReceiveDamage;
		public event Action<IEntity, int> OnHeal;
		public event Action<IEntity> OnHpChange;
		public event Action<IEntity> OnDeath;
		public event Action<IEntity, int> OnAddGuard;
		public event Action<IEntity, bool> ChangeInvincibleValue;
		public event Action<IEntity, Vector3> OnMove;
        
		//==================================================||Properties 
        
		public readonly CardInventory CardInventory = new();
		public Level Level { get; private set; } = new();

		public Vector3 Pos => transform.position;
		public IMovement Movement { get; private set; }
		public IAttack Attack { get; private set; }

		public IEnumerable<StatusEffectBase> StatusEffects => _statusEffects;

		public bool IsInvincible {
			get => _isInvincible;
			set {
				_isInvincible = value;
				ChangeInvincibleValue?.Invoke(this, _isInvincible);
			}
		}
		
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
		private bool _isInvincible = false;
		private float _damageDownMultiplier = 1;
		private List<StatusEffectBase> _statusEffects = new();
        
		//==================================================||Methods 
		[TestMethod]
		public void ReceiveDamage(int pAmount) {

			if (IsInvincible) {
				//OnReceiveDamage?.Invoke(this, 0, true);
				//CardInventory.OnReceiveDamage(this, 0);
				return;
			}

			pAmount = Mathf.CeilToInt(pAmount * _damageDownMultiplier);
			var guardApplied = false;
			var damage = pAmount;
			if (Guard > 0) {
				guardApplied = true;
				if (Guard >= pAmount) {
					Guard -= pAmount;
					pAmount = 0;
				}
				else {
					pAmount -= Guard;
					Guard = 0;
				}
			}
            
			Hp = Mathf.Max(Hp - pAmount, 0);
            
			OnHpChange?.Invoke(this);
			OnReceiveDamage?.Invoke(this, damage, guardApplied);
			CardInventory.OnReceiveDamage(this, pAmount);
			if (Hp <= 0) {
				CardInventory.OnDeath(this);
				//Card might recover player's hp
				if(Hp <= 0)
					OnDeath?.Invoke(this);
			}
		}

		[TestMethod]
		public void Heal(int pAmount) {
			Hp = Mathf.Min(Hp + pAmount, MaxHp);
			OnHpChange?.Invoke(this);
			OnHeal?.Invoke(this, pAmount);
			CardInventory.OnHeal(this, pAmount);
		}

		[TestMethod]
		public void AddGuard(int pAmount) {
			Guard += pAmount;
			OnAddGuard?.Invoke(this, pAmount);
			CardInventory.OnAddGuard(this, pAmount);
		}

		public void AddStatusEffectBase(StatusEffectBase pEffect) {
			pEffect.StartEffect(this);
			_statusEffects = _statusEffects.Where(effect => effect.Alive).ToList();
			_statusEffects.Add(pEffect);
		}

		//==================================================||Unity 
		private void Awake() {
			Movement = new KeyboardMovement(5);
			Attack = new ProjectileAttack(this, 5, 15, 1, 0.3f, 30f);          
		}
       
		private void Update() {
			
			var velo = Movement.GetDelta(this);
			OnMove?.Invoke(this, velo);
			transform.position += velo * Time.deltaTime;
			
			foreach (var effect in _statusEffects) {
				effect.Update(this);
			}
			CardInventory.Update(this);
			Attack.Update();
		}

		[TestMethod] private void SetIv(bool pV) => IsInvincible = pV;
		[TestMethod] private void GetExp(int pV) => Level.GetExp(pV);
	}
}