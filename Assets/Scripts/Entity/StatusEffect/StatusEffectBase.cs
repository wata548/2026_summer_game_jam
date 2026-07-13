using Entity;
using UnityEngine;

namespace StatusEffect {
	public abstract class StatusEffectBase {
		
		//==================================================Properties	
		public bool Alive => _duration >= 0; 
		
		//==================================================Fields	
		private float _duration;
		
		//==================================================Constructors	
		protected StatusEffectBase(float pDuration, IEntity pTarget) {
			_duration = pDuration;
			StartEffect(pTarget);
		}
		
		//==================================================Methods	
		public virtual void StartEffect(IEntity pTarget) { }
		public virtual void ExitEffect(IEntity pTarget){}
		protected virtual void UpdateEffect(IEntity pTarget) {}
		public void Update(IEntity pTarget) {
			if (!Alive) return;
			
			_duration -= Time.deltaTime;
			UpdateEffect(pTarget);
			if(!Alive) ExitEffect(pTarget);
		}
	}
}