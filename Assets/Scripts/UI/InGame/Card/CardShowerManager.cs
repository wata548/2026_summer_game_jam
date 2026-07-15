using System;
using System.Collections.Generic;
using Card.Inventory;
using Entity;
using UnityEngine;

namespace UI.InGame.Card {
	public class CardShowerManager: MonoBehaviour {
		[SerializeField] private CardShower _shower;
		private List<CardShower> _list = new();
		private void OnCardUpdated(CardInventory pInventory) {
			int idx = 0;
			foreach (var card in pInventory.Cards) {
				if(_list.Count <= idx) _list.Add(Instantiate(_shower, transform));
				_list[idx].SetCard(card);
				idx++;
			}
		}
		
		private void Start() {
			Player.Instance.CardInventory.OnCardUpdated += OnCardUpdated;
		}
	}
}