using System;
using Entity.AttackModule;
using Movement;
using UnityEngine;

namespace Entity {
	public class DefaultEnemy: MonoBehaviour, IEntity {
		
		public event Action<IEntity, int, bool> OnReceiveDamage;
		public event Action<IEntity> OnDeath;
		public event Action<IEntity, int> OnHeal;
		public event Action<IEntity, int> OnAddGuard;

		public Vector3 Pos => transform.position;
		public IMovement Movement { get; private set; } = new TracePlayer();
		public IAttack Attack { get; }
		public bool IsInvincible { get; set; }
		public int MaxHp { get; set; }
		public int Hp { get; }
		public int Guard { get; }
		public float DamageDownMultiplier { get; set; }
		public void ReceiveDamage(int pAmount) {
			throw new NotImplementedException();
		}
		public void Heal(int pAmount) {
			throw new NotImplementedException();
		}
		public void AddGuard(int pAmount) {
			throw new NotImplementedException();
		}
	}
}