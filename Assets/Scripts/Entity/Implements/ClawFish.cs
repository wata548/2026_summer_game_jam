using Entity.AttackModule;
using Entity.AttackModule.Implements.Player;
using UnityEngine;

namespace Entity {
	[RequireComponent(typeof(SpriteRenderer))]
	public class ClawFish: DefaultEnemy {
		[SerializeField] protected int _damage;
		private SpriteRenderer _render;
		
		public override IAttack Attack { get; protected set; }

		private void OnMoveCallBack(IEntity pTarget, Vector3 pDelta) {
			if (pDelta.x == 0) return;
			_render.flipX = pDelta.x < 0;
		}
		
		protected override void Awake() {
			base.Awake();
			_render = GetComponent<SpriteRenderer>();
			Attack = new Body(this, _damage);
			OnMove += OnMoveCallBack;	
		}
	}
}