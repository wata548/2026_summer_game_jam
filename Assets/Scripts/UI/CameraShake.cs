using System;
using DG.Tweening;
using Entity;
using UnityEngine;

namespace Data.UI {
	[RequireComponent(typeof(Camera))]
	public class CameraShake:MonoBehaviour {
		private Camera _camera;
		private Tween _animation;
		private const float Duration = 0.1f;

		private void OnReceiveDamage(IEntity _, int pDamage, bool pGuarded) {
			_animation?.Kill();
			_camera.transform.localPosition = new(0, 0, -4);
			_animation = _camera.DOShakePosition(Duration, 0.2f, fadeOut: false);
		}
		
		private void Start() {
			_camera = GetComponent<Camera>();
			Player.Instance.OnReceiveDamage += OnReceiveDamage;
		}
	}
}