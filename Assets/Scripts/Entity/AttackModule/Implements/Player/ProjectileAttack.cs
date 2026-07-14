using System;
using UnityEngine;

namespace Entity.AttackModule.Implements.Player {
	public class ProjectileAttack: IProjectileAttack, ICoolTimeAttack, IMultipleAttack, IAttack {

		public event Action OnAttack;
		public event Action CoolDownAnimation;

		//==================================================||Properties 
		public IEntity Owner { get; }
        
		public int Power => Mathf.CeilToInt(_power * PowerMultiplier);
		public float PowerMultiplier {
			get => _powerMultiplier; 
			set => _powerMultiplier = Mathf.Max(value, 0);
		}
        
		public float CoolTime => _coolTime * CoolTimeMultiplier;
		public float CoolTimeMultiplier {
			get => _coolTimeMultiplier;
			set => _coolTimeMultiplier = Mathf.Max(value, 0);
		}

		public int AttackCnt {
			get => _attackCnt;
			set => _attackCnt = Mathf.Max(value, 0);
		}

		public float Range { get; }

		public float Speed => _speed * _speedTimeMultiplier;
		public float SpeedMultiplier {
			get => _speedTimeMultiplier;
			set => _speedTimeMultiplier = Mathf.Max(value, 0);
		}

		//==================================================||Fields 
		private int _attackCnt = 1; 
		private bool _coolDownAnimation = false; 
        
		private int _power; 
		private float _powerMultiplier = 1; 
        
		private readonly float _coolTime; 
		private float _coolTimeMultiplier = 1;

		private readonly float _speed; 
		private float _speedTimeMultiplier = 1;
        
		private float _remainTime = 0;
		private readonly float _coolDownAnimationTerm = 0;
        
		//==================================================||Constructors 
		public ProjectileAttack(IEntity pUser, int pPower, float pSpeed, int pAttackCnt = 1, float pCoolTime = 0.5f, float pRange = 60f, float pCoolDownAnimatinoTerm = 0.1f) {
			Owner = pUser;
			_power = pPower;
			_speed = pSpeed;
			_attackCnt = pAttackCnt;
			_coolTime = pCoolTime;
			Range = pRange * Mathf.Deg2Rad;
			_coolDownAnimationTerm = pCoolDownAnimatinoTerm;
		}  
        
		//==================================================||Methods 
		private void Generate(float pRadian) {
			var newProjectile = ProjectilePool.Instance.Pool.Get();
			newProjectile.Init(Owner, "Player", Vector3.one, Speed, Power, pRadian);
		}

		public void AddDefaultPower(int pPoint) {
			_power += pPoint;
		}

		public void Update() {
			if (Time.timeScale == 0) return;
			
			if (_remainTime < CoolTime) {
				if (!_coolDownAnimation && _remainTime >= CoolTime - _coolDownAnimationTerm) {
					CoolDownAnimation?.Invoke();
					_coolDownAnimation = true;
				}
				_remainTime += Time.deltaTime;
				return;
			}

			if (!_coolDownAnimation) {
				CoolDownAnimation?.Invoke();
				_coolDownAnimation = true;
			}

			if (!Input.GetKeyDown(KeyCode.Mouse0)) return;

			_coolDownAnimation = false;
			_remainTime = 0;
			OnAttack?.Invoke();
			var mousePos = Input.mousePosition;
			mousePos.x -= Screen.width / 2f;
			mousePos.y -= Screen.height / 2f;
			var radian = Mathf.Atan2(mousePos.y, mousePos.x);
			if (_attackCnt == 1) {
				Generate(radian);
				return;
			}

			var term = Range / (_attackCnt - 1);
			radian -= Range / 2f;
			for(int i = 0; i < _attackCnt; i++, radian += term)
				Generate(radian);
		}
	}
}