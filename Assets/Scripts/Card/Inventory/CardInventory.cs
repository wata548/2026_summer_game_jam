using System;
using System.Collections.Generic;
using System.Linq;
using Entity;

namespace Card.Inventory {
	public class CardInventory {
		//==================================================||Properties 
		public int Cnt => _cards.Count;
		public IEnumerable<CardBase> Cards => _cards.Select(card => card);
        
		//==================================================||Fields 
		private readonly List<CardBase> _cards = new();

		//==================================================||Methods 
		public void Get(IEntity pTarget, int pId) {
			var temp = _cards.FirstOrDefault(card => card.Id == pId);
			if (temp != null) {
				temp.LevelUp(pTarget);
				return;
			}
                
			var targetType = Type.GetType($"Card.Card{pId}")!;
			var instance = (Activator.CreateInstance(targetType) as CardBase)!;
			instance.ApplyPassive(pTarget, true);
			_cards.Add(instance);
		}

		public bool Remove(IEntity pTarget, int pId) {
			var temp = _cards.FirstOrDefault(card => card.Id == pId);
			if (temp == null) return false;
            
			temp.ApplyPassive(pTarget, false);
			temp.OnRemove(pTarget);
			_cards.Remove(temp);
			return true;
		}

		public void Update(IEntity pTarget) {
			foreach (var card in _cards) {
				if(!card.IsActive) continue;
				card.Update(pTarget);
			}
				
		}

		//==================================================||CallBacks 
		public void OnReceiveDamage(IEntity pTarget, int pAmount) {
			foreach (var card in _cards) {
				if(!card.IsActive) continue;
				card.OnReceiveDamage(pTarget, pAmount);
			}
		}
        
		public void OnDeath(IEntity pTarget) {
			foreach (var card in _cards) {
				if(!card.IsActive) continue;
				card.OnDeath(pTarget);
			}
		}
		public void OnHeal(IEntity pTarget, int pAmount) {
			foreach (var card in _cards) {
				if(!card.IsActive) continue;
				card.OnHeal(pTarget, pAmount);
			}
		}
		public void OnAddGuard(IEntity pTarget, int pAmount) {
			foreach (var card in _cards) {
				if(!card.IsActive) continue;
				card.OnAddGuard(pTarget, pAmount);
			}
		}
	}
}