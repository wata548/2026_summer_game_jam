using System;
using Entity;
using UnityEngine;

namespace Data.Skill {
	public abstract class InteractWithMonster: MonoBehaviour {
		public abstract void ContactWithEnemy(IEntity pTarget);
		
		public void OnCollisionEnter2D(Collision2D other) {
			var entity = other.gameObject.GetComponent<IEntity>();
			if (entity == null) return;
			if (entity is Player) return;
			ContactWithEnemy(entity);
		}
	}
}