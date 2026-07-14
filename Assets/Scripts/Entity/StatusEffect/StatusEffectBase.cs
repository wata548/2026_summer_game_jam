using Entity;
using UnityEngine;

namespace StatusEffect {
	public abstract class StatusEffectBase {
		
		//==================================================Properties	
		public bool Alive => Duration >= 0; 
		public abstract int Id { get; }

		//==================================================Fields	
		public float Duration { get; private set; }
		private bool _init = false;
		
		//==================================================Constructors	
		protected StatusEffectBase(float pDuration) {
			Duration = pDuration;
		}
		
		//==================================================Methods	
		public void SetDuration(float pDuration) => Duration = pDuration;
		protected void End() => Duration = 0;
		public virtual void StartEffect(IEntity pTarget) { }
		public virtual void ExitEffect(IEntity pTarget){}
		protected virtual void UpdateEffect(IEntity pTarget) {}
		public void Update(IEntity pTarget) {
			if (!_init) {
				_init = true;
				StartEffect(pTarget);
			}
			
			if (!Alive) return;
			
			Duration -= Time.deltaTime;
			UpdateEffect(pTarget);
			if(!Alive) ExitEffect(pTarget);
		}
	}
}