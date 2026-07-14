using System;
using Extension.ObjectPool;
using UnityEngine;

namespace Entity {
	public class ExperienceBall: ObjBase<ExperienceBall> {
		private static float _speed = 8; 
		private const int _dropExp = 5;

		private void OnTriggerEnter2D(Collider2D other) {
			if (!other.gameObject.CompareTag("Player")) return;
			Player.Instance.Level.GetExp(_dropExp);
			Destroy(gameObject);
		}

		private void Update() {
			var direction = (Player.Instance.Pos - transform.position).normalized;
			transform.position +=  _speed * Time.deltaTime * direction;
		}
	}
}