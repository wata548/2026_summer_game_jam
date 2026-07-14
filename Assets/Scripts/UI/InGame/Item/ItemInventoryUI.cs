using System;
using System.Collections.Generic;
using Entity;
using Item;
using UnityEngine;

namespace UI.InGame.Item {
	public class ItemInventoryUI: MonoBehaviour {
		[SerializeField] private ItemShower _prefab;
		private List<ItemShower> _itemShowers = new();
		private const float ItemTerm = 0.2f; 

		private void OnChangeInventorySize(ItemInventory pItemInventory) {
			
			var anchor = new Vector2(1, 0.5f);
			while (_itemShowers.Count < pItemInventory.InventoryAmount) {
				var newSlot = Instantiate(_prefab, transform);
				var rect = (newSlot.transform as RectTransform)!;
				rect.anchorMin = anchor;
				rect.anchorMax = anchor;
				
				var term = rect.sizeDelta.x * (1 + ItemTerm);
				var delta = new Vector2(-term * _itemShowers.Count, 0);
				rect.localPosition = delta;
				_itemShowers.Add(newSlot);
				OnChangeContext(pItemInventory, _itemShowers.Count - 1);
			}
		}

		private void OnChangeContext(ItemInventory pItemInventory, int pIdx) {
			if (_itemShowers.Count <= pIdx) return;
			_itemShowers[pIdx].SetItem(pItemInventory.GetItemId(pIdx), (pIdx + 1).ToString());
		}
		
		private void Start() {
			Player.Instance.ItemInventory.OnChangeInventorySize += OnChangeInventorySize;
			Player.Instance.ItemInventory.OnUse += OnChangeContext;
			Player.Instance.ItemInventory.OnGet += OnChangeContext;
			Player.Instance.ItemInventory.OnRemove += OnChangeContext;
			Player.Instance.ItemInventory.AddInventorySize(0);
		}
	}
}