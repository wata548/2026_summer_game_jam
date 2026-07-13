using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Card
{
	class Card1009 : CoolTimeCard
	{
		public override float[] CoolTime => _coolTime;

		public override float[] Duration => _duration;
		private readonly float[] _coolTime = {30, 20, 20};
		private readonly float[] _duration = {2, 3, 5};
        
		public override int Id => 1009;

		public override bool IsActive { protected set => throw new NotImplementedException(); }

		public override void EnterSkill(IEntity pTarget)
		{
			pTarget.IsInvincible = true;
		}
		public override void ExitSkill(IEntity pTarget)
		{
			pTarget.IsInvincible = false;
		}
	}
}