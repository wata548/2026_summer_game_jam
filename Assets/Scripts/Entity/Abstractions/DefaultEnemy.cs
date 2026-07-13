using System;
using System.Collections.Generic;
using System.Linq;
using Entity.AttackModule;
using Movement;
using StatusEffect;
using UnityEngine;

namespace Entity {
	public abstract class DefaultEnemy: MonoBehaviour, IEntity {
		
		//==================================================Events	
		public event Action<IEntity, int, bool> OnReceiveDamage;
		public event Action<IEntity> OnDeath;
		public event Action<IEntity, int> OnHeal;
		public event Action<IEntity, int> OnAddGuard;
		
		//==================================================Fields	
		
		[Header("Stat")]
		[SerializeField] private float _speed;
		[SerializeField] private float _traceRange;
		[SerializeField] private int _maxHp;
		private float _damageDownMultiplier = 1;
		private StatusEffectBase _statusEffect = null;
		private List<StatusEffectBase> _statusEffects = new();
		
		//==================================================Properties	
		
		public Vector3 Pos => transform.position;
		public IMovement Movement { get; protected set; }
		public IAttack Attack { get; protected set; }
		public IEnumerable<StatusEffectBase> StatusEffects => _statusEffects;
		public bool IsInvincible { get; set; } = false;
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
		public int Hp { get; private set; }
		[field: SerializeField]public int Guard { get; private set; }
		public float DamageDownMultiplier {
			get => _damageDownMultiplier;
			set => _damageDownMultiplier = Mathf.Max(value, 0);
		}
		
		//==================================================Methods	
		public void ReceiveDamage(int pAmount) {

			if (IsInvincible) {
				OnReceiveDamage?.Invoke(this, 0, true);
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
			if (Hp <= 0) {
				OnDeath?.Invoke(this);
			}
		}

		public void Heal(int pAmount) {
			Hp = Mathf.Min(Hp + pAmount, MaxHp);
			OnHeal?.Invoke(this, pAmount);
		}

		public void AddGuard(int pAmount) {
			Guard += pAmount;
			OnAddGuard?.Invoke(this, pAmount);
		}
		
		public void AddStatusEffectBase(StatusEffectBase pEffect) {
			pEffect.StartEffect(this);
			_statusEffects = _statusEffects.Where(effect => effect.Alive).ToList();
			_statusEffects.Add(pEffect);
		}

		//==================================================Unity	
		protected virtual void Awake() {
			Movement = new TracePlayer(_speed, _traceRange);
			Hp = MaxHp;
		}

		protected virtual void Update() {
			transform.position += Movement.GetDelta(this);
			foreach (var effect in _statusEffects) {
				effect.Update(this);
			}
			Attack.Update();
		}
	}
}