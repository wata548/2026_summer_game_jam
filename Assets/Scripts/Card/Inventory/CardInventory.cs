using System;
using System.Collections.Generic;
using System.Linq;
using Entity;

namespace Card.Inventory {
    public class CardInventory {
        //==================================================||Fields 
        private readonly List<CardBase> _cards = new();

        //==================================================||Methods 
        public void Get(IEntity pTarget, int pId) {
            var temp = _cards.FirstOrDefault(card => card.Id == pId);
            if (temp != null) {
                temp.LevelUp();
                return;
            }
                
            var targetType = Type.GetType($"Card.Card{pId}")!;
            var instance = (Activator.CreateInstance(targetType) as CardBase)!;
            instance.OnGet(pTarget);
            _cards.Add(instance);
        }

        public void Update(IEntity pTarget) {
            foreach(var card in _cards)
                card.Update(pTarget);
        }

        //==================================================||CallBacks 
        public void OnReceiveDamage(IEntity pTarget, int pAmount) {
            foreach(var card in _cards)
                card.OnReceiveDamage(pTarget, pAmount);
        }
        
        public void OnDeath(IEntity pTarget) {
            foreach(var card in _cards)
                card.OnDeath(pTarget);
        }
        public void OnHeal(IEntity pTarget, int pAmount) {
            foreach(var card in _cards)
                card.OnHeal(pTarget, pAmount);
        }
        public void OnAddGuard(IEntity pTarget, int pAmount) {
            foreach(var card in _cards)
                card.OnAddGuard(pTarget, pAmount);
        }
    }
}