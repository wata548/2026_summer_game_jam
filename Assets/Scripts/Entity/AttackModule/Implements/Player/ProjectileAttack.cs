using UnityEngine;

namespace Entity.AttackModule.Implements.Player {
	public class ProjectileAttack: IProjectileAttack, ICoolTimeAttack, IMultipleAttack, IAttack {
        
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
        
		private int _power; 
		private float _powerMultiplier = 1; 
        
		private readonly float _coolTime; 
		private float _coolTimeMultiplier = 1;

		private readonly float _speed; 
		private float _speedTimeMultiplier = 1;
        
		private float _remainTime = 0;
        
		//==================================================||Constructors 
		public ProjectileAttack(IEntity pUser, int pPower, float pSpeed, int pAttackCnt = 1, float pCoolTime = 0.5f, float pRange = 60f) {
			Owner = pUser;
			_power = pPower;
			_speed = pSpeed;
			_attackCnt = pAttackCnt;
			_coolTime = pCoolTime;
			Range = pRange * Mathf.Deg2Rad;
		}  
        
		//==================================================||Methods 
		private void Generate(float pRadian) {
			var newProjectile = ProjectilePool.Instance.Pool.Get();
			newProjectile.Init(Owner, Speed, Power, pRadian);
		}

		public void AddDefaultPower(int pPoint) {
			_power += pPoint;
		}

		public void Update() {
			if (_remainTime < CoolTime) {
				_remainTime += Time.deltaTime;
				return;
			}

			if (!Input.GetKeyDown(KeyCode.Mouse0)) return;
            
			_remainTime = 0;
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