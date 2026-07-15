using System;
using DG.Tweening;
using Entity;
using UnityEngine;

namespace Data.UI {
	[RequireComponent(typeof(IEntity))]
	[RequireComponent(typeof(SpriteRenderer))]
	public class OnDamageReceive: MonoBehaviour {

		private SpriteRenderer _renderer;
		private Tween _animation;
		private void ReceiveDamage(IEntity pTarget, int pDamage, bool pGuard) {
			var value = 0f;
			_animation = DOTween.Sequence()
				.Append( DOTween.To( () => value, x => {
							value = x;
							_renderer.material.SetFloat("_Process", x);
						}, 
						1f, 0.2f
					).SetEase(Ease.OutSine)
				).Append( DOTween.To( () => value, x => {
							value = x;
							_renderer.material.SetFloat("_Process", x);
						}, 
						0f, 0.2f
					).SetEase(Ease.OutSine)
				);
			

		}
		
		private void Awake() {
			_renderer = GetComponent<SpriteRenderer>();
			GetComponent<IEntity>().OnReceiveDamage += ReceiveDamage;
		}
	}
}