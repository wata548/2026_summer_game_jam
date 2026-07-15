using System;
using System.Collections.Generic;
using System.Linq;
using Extension.ObjectPool;
using UnityEngine;

namespace Entity.AttackModule.Implements {
	[RequireComponent(typeof(SpriteRenderer))]
	public class Projectile: ObjBase<Projectile> {
		private const float LimitSqrDistance = 20 * 20;
		private static IReadOnlyDictionary<string, Sprite> _images = null;
		private IEntity _owner;
		private int _power;
		private Vector3 _velocity;  
		private SpriteRenderer _renderer;

		public void Init(IEntity pOwner, string pSprite, Vector3 pScale, float pSpeed, int pPower, float pRadian) {
			Awake();
			transform.localScale = pScale;
			_renderer.sprite = _images[pSprite];
			_owner = pOwner;
			_power = pPower;
			_velocity = new Vector3(Mathf.Cos(pRadian), Mathf.Sin(pRadian)) * pSpeed;
			transform.rotation = Quaternion.Euler(0, 0, pRadian * Mathf.Rad2Deg);
			transform.position = pOwner.Pos;
		}
		public void Init(IEntity pOwner, string pSprite, Vector3 pScale, Vector3 pSpeed, int pPower) {
			Awake();
			transform.localScale = pScale;
			_renderer.sprite = _images[pSprite];
			_owner = pOwner;
			_power = pPower;
			_velocity = pSpeed;
			var radian = Mathf.Atan2(pSpeed.y, pSpeed.x);
			transform.rotation = Quaternion.Euler(0, 0, radian * Mathf.Rad2Deg);
			transform.position = pOwner.Pos;
		}

		private void Update() {
			if (!IsExist) return;
			transform.position += _velocity * Time.deltaTime;
			if (_owner.Hp <= 0) {
				Hide();
				return;
			}
			if((_owner.Pos - transform.position).sqrMagnitude >= LimitSqrDistance)
				Hide();
		}

		private void Awake() {
			_images ??= Resources.LoadAll<Sprite>("Projectiles")
				.ToDictionary(sprite => sprite.name, sprite => sprite);
			_renderer = GetComponent<SpriteRenderer>();
		}

		private void OnTriggerEnter2D(Collider2D other) {
			var entity = other.GetComponent<IEntity>();
			if (entity == null) return;
			var isPlayer = _owner is Entity.Player;
			var targetIsPlayer = entity is Entity.Player;
			
			if (isPlayer != targetIsPlayer) {
				entity.ReceiveDamage(_power);
				Hide();
			}
		}
	}
}