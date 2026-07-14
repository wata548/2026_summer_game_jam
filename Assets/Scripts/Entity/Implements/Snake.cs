using Entity.AttackModule;
using Entity.AttackModule.Implements.Player;
using UnityEngine;

namespace Entity {
	[RequireComponent(typeof(SpriteRenderer))]
	[RequireComponent(typeof(Animator))]
	public class Snake: DefaultEnemy {
		[SerializeField] private DefaultEnemy _after;
		[SerializeField] private string _name;
		[SerializeField] private int _power;
		[SerializeField] private int _projectilePower;
		[SerializeField] private float _projectileSpeed;
		[SerializeField] private float _attackCool;
		[SerializeField] private Vector3 _projectileScale;
		private Animator _animator;
		private SpriteRenderer _renderer;
		public override IAttack Attack { get; protected set; }

		protected override void Death(IEntity pTarget) {
			if (_after != null) {
				var newMob = Instantiate(_after);
				newMob.transform.position = transform.position;	
			}
			base.Death(pTarget);
		}

		private void OnMoveCallBack(IEntity pTarget, Vector3 pDelta) {
			_animator.SetBool("Moving", pDelta.sqrMagnitude > 0);
			if (pDelta.x == 0) return;
			_renderer.flipX = pDelta.x < 0;
		}

		private void CoolDown() {
			Debug.Log("SDf");
			_animator.Play("Attack", 0);
		} 

		protected override void Awake() {
			base.Awake();
			_animator = GetComponent<Animator>();
			_renderer = GetComponent<SpriteRenderer>();
			OnMove += OnMoveCallBack;
			Attack = new BodyAndProjectileAttack(
				this,
				_name,
				_projectileScale,
				_power,
				_projectilePower,
				_projectileSpeed,
				_attackCool,
				_traceRange,
				0.2f
			);
			Attack.CoolDownAnimation += CoolDown;
		}
	}
}