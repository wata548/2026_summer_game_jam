using System;

namespace Entity.AttackModule {
	public interface ICloseAttack {
		void OnAttacked(IEntity pTarget);
	}
}