using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Card
{
	class Card1012 : CoolTimeCard
	{
		public override bool IsActive { protected set => throw new NotImplementedException(); }
		public override float[] CoolTime => _coolTime;
		public override float[] Duration => _duration;
		private readonly float[] _coolTime = { 30, 20, 20 };
		private readonly float[] _duration = { 10, 10, 5 };
		private readonly int[] _deltaMaxHp = { 50, 60, 60};
		private bool _level3Actived = false;
		private float _remainTime;
        
		public override int Id => 1012;

		public override void EnterSkill(IEntity pTarget)
		{
			pTarget.Movement.MoveFlip = true;
			pTarget.MaxHp += _deltaMaxHp[Level];
			if(Level == 2)
				_level3Actived = true;
		}
		public override void ExitSkill(IEntity pTarget)
		{
			pTarget.Movement.MoveFlip = false;
			if(Level != 2)
				pTarget.MaxHp -= _deltaMaxHp[Level];
		}

		public override void Update(IEntity pTarget) {
			base.Update(pTarget);
			if (_level3Actived) {
				_remainTime -= Time.deltaTime;
				if (_remainTime > 0) return;
				_level3Actived = false;
				pTarget.MaxHp -= _deltaMaxHp[Level];
			}
		}

		public override void OnRemove(IEntity pTarget) {
			if(IsActive) ExitSkill(pTarget);
			if(_level3Actived) pTarget.MaxHp -= _deltaMaxHp[Level];
		}
	}
}