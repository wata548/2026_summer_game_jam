using Entity.AttackModule.Implements.Player;
using UnityEngine;

namespace Entity {
	[RequireComponent(typeof(Animator))]
	public class Lion:ClawFish {

		[SerializeField] private float _attackDistance = 1;
		private Animator _animator;
		private bool _lastValue = false;

		protected override void Awake() {
			base.Awake();
			_animator = GetComponent<Animator>();
			Attack = new BodyWithBleeding(this, _damage);
		}

		protected override void Update() {
			base.Update();
			var value = (Player.Instance.Pos - transform.position).sqrMagnitude <= _attackDistance * _attackDistance;
			if (value == _lastValue) return;
			_lastValue = value;
			_animator.SetBool("IsClose", value);

		}
	}
}