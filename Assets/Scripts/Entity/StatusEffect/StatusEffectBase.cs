using Entity;
using UnityEngine;

namespace StatusEffect {
	public abstract class StatusEffectBase {
		
		//==================================================Properties	
		public bool Alive => _duration >= 0; 
		
		//==================================================Fields	
		private float _duration;
		private bool _init = false;
		
		//==================================================Constructors	
		protected StatusEffectBase(float pDuration) {
			_duration = pDuration;
		}
		
		//==================================================Methods	
		public virtual void StartEffect(IEntity pTarget) { }
		public virtual void ExitEffect(IEntity pTarget){}
		protected virtual void UpdateEffect(IEntity pTarget) {}
		public void Update(IEntity pTarget) {
			if (!_init) {
				_init = true;
				StartEffect(pTarget);
			}
			
			if (!Alive) return;
			
			_duration -= Time.deltaTime;
			UpdateEffect(pTarget);
			if(!Alive) ExitEffect(pTarget);
		}
	}
}