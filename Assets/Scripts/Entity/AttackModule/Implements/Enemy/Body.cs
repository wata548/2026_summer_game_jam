using System;
using UnityEngine;

namespace Entity.AttackModule.Implements.Player {
	public class Body: IAttack, ICloseAttack {
		public event Action OnAttack;
		public event Action CoolDownAnimation;
		public IEntity Owner { get; }
		public int Power => Mathf.CeilToInt(_power * PowerMultiplier);
		public float PowerMultiplier {
			get => _powerMultiplier; 
			set => _powerMultiplier = Mathf.Max(value, 0);
		}
		private int _power;
		private float _powerMultiplier = 1;
		public void AddDefaultPower(int pPoint) => _power += pPoint;

		public Body(IEntity pOwner, int pPower) =>
			(Owner, _power) = (pOwner, pPower);
		
		public virtual void Update() {}
		public virtual void OnAttacked(IEntity pTarget) {}
	}
}