using Entity;
using UnityEngine;

namespace Data.Skill {
	public class Knife: InteractWithMonster {
		[SerializeField] private int _damage;
		public void Set(int pDamage) => _damage = pDamage;

		public override void ContactWithEnemy(IEntity pTarget) =>
			pTarget.ReceiveDamage(Mathf.CeilToInt(_damage * Player.Instance.Attack.PowerMultiplier));
	}
}