using Entity;
using UnityEngine;

namespace UI.InGame {
	[RequireComponent(typeof(IEntity))]
	[RequireComponent(typeof(Animator))]
	[RequireComponent(typeof(SpriteRenderer))]
	public class PlayerAnimation: MonoBehaviour {

		[SerializeField] private Material _invincibleMaterial;
		private Material _defaultMaterial;
		private Animator _animator;
		private SpriteRenderer _renderer;

		private void ChangeInvincibleValue(IEntity pTarget, bool pValue) =>
			_renderer.material = pValue 
				? _invincibleMaterial 
				: _defaultMaterial;
		
		private void OnMove(IEntity pTarget, Vector3 pVelocity) {
			var length = pVelocity.sqrMagnitude;
			_animator.SetFloat("Length", length);
			
			if (length > 0.1f) {
				_animator.SetFloat("Y", pVelocity.y);
				_animator.SetFloat("X", pVelocity.x);
			}
		}
		
		private void Start() {
			Cursor.lockState = CursorLockMode.Confined;
			_animator = GetComponent<Animator>();
			_renderer = GetComponent<SpriteRenderer>();
			_defaultMaterial = _renderer.material;
			
			var player = GetComponent<IEntity>();
			player.OnMove += OnMove;
			player.ChangeInvincibleValue += ChangeInvincibleValue;
		}
	}
}