using System;
using UnityEngine;

namespace Entity.AttackModule.Implements.Player {
	public class BodyAndProjectileAttack: IProjectileAttack, ICoolTimeAttack, IAttack {
        
		//==================================================||Properties 
		public event Action OnAttack;
		public event Action CoolDownAnimation;
		public IEntity Owner { get; }
        
		public int Power => Mathf.CeilToInt(_power * PowerMultiplier);
		private int projectilePower => Mathf.CeilToInt(_projectilePower * PowerMultiplier);
		public float PowerMultiplier {
			get => _powerMultiplier; 
			set => _powerMultiplier = Mathf.Max(value, 0);
		}
        
		public float CoolTime => _coolTime * CoolTimeMultiplier;
		public float CoolTimeMultiplier {
			get => _coolTimeMultiplier;
			set => _coolTimeMultiplier = Mathf.Max(value, 0);
		}

		public float Speed => _speed * _speedTimeMultiplier;
		public float SpeedMultiplier {
			get => _speedTimeMultiplier;
			set => _speedTimeMultiplier = Mathf.Max(value, 0);
		}

		//==================================================||Fields 
		private float _traceRange; 
		
		private readonly string _name; 
		private int _power; 
		private readonly int _projectilePower; 
		private float _powerMultiplier = 1; 
        
		private readonly float _coolTime; 
		private float _coolTimeMultiplier = 1;

		private readonly float _speed; 
		private float _speedTimeMultiplier = 1;
        
		private float _remainTime = 0;
		private readonly float _animationTerm = 0;
		private bool _coolDownAnimation = false;
		private Vector3 _scale;
        
		//==================================================||Constructors 
		public BodyAndProjectileAttack(IEntity pUser, string pName, Vector3 pScale, int pPower, int pProjectilePower, float pSpeed, float pCoolTime, float pTrace, float pAnimatinoTerm) {
			Owner = pUser;
			_name = pName;
			_projectilePower = pProjectilePower;
			_power = pPower;
			_speed = pSpeed;
			_coolTime = pCoolTime;
			_traceRange = pTrace;
			_scale = pScale;
			_animationTerm = pAnimatinoTerm;
		}  
        
		//==================================================||Methods 
		private void Generate(Vector3 pDirection) {
			var newProjectile = ProjectilePool.Instance.Pool.Get();
			newProjectile.Init(Owner, _name, _scale, pDirection * Speed, projectilePower);
		}

		public void AddDefaultPower(int pPoint) {
			_power += pPoint;
		}

		public void Update() {
			if (_remainTime < CoolTime) {
				_remainTime += Time.deltaTime;
				if ((Entity.Player.Instance.Pos - Owner.Pos).sqrMagnitude > _traceRange * _traceRange)
					return;
				
				if (!_coolDownAnimation && _remainTime >= CoolTime - _animationTerm) {
					CoolDownAnimation?.Invoke();
					_coolDownAnimation = true;
				}
				return;
			}
			
			if ((Entity.Player.Instance.Pos - Owner.Pos).sqrMagnitude > _traceRange * _traceRange)
				return;
			
			if(!_coolDownAnimation)
				CoolDownAnimation?.Invoke();

			_coolDownAnimation = false;
			OnAttack?.Invoke();
			_remainTime = 0;
			var direction = (Entity.Player.Instance.Pos - Owner.Pos).normalized;
			Generate(direction);
		}
	}
}