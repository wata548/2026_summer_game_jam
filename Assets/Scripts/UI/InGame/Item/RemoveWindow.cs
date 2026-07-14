using System;
using System.Collections.Generic;
using Entity;
using Item;
using UnityEngine;

namespace UI.InGame.Item {
	public class RemoveWindow: MonoBehaviour {
		[SerializeField] private GameObject _window;
		[SerializeField] private ItemShowerButton _removeItem;
		[SerializeField] private Transform _range;
		private List<ItemShowerButton> _showers = new();
		private bool _isActive = false;
		private Queue<int> _candidate = new();

		private void OnCandidateAdded(ItemInventory _, int pCandidate) => _candidate.Enqueue(pCandidate);
		
		private void StateUpdate() {
			_removeItem.SetItem(_candidate.Dequeue(), "New Item");
			
			var inventory = Player.Instance.ItemInventory;
			while (_showers.Count < Player.Instance.ItemInventory.InventoryAmount) {
				var newSlot = Instantiate(_removeItem, _range);
				newSlot.SetIdx(_showers.Count);
				newSlot.transform.localPosition = Vector2.zero;
				_showers.Add(newSlot);
			}

			var pivot = new Vector2(1, 0.5f);
			var term = 1f / (_showers.Count - 1);
			var idx = 0;
			foreach (var shower in _showers) {
				shower.SetItem(
					inventory.GetItemId(idx++),
					idx.ToString()
				);
				
				var rect = shower.transform as RectTransform;
				rect.anchorMin = pivot;
				rect.anchorMax = pivot;
				pivot.x -= term;
			}
		}

		private void Show() {
			_isActive = true;
			_window.SetActive(true);
			Time.timeScale = 0;
			StateUpdate();
		}

		private void Hide() {
			_isActive = false;
			_window.SetActive(false);
			Time.timeScale = 1;
		}

		private void Start() {
			ItemShowerButton.Init(Hide);
			_removeItem.SetIdx(-1);
			Player.Instance.ItemInventory.OnCandidateAdded += OnCandidateAdded;
		}

		private void Update() {
			if (_isActive) return;
			
			if(_candidate.Count > 0)
				Show();
		}
	}
}