using System;
using System.Collections.Generic;
using System.Linq;

namespace Item {
	public class ItemInventory {

		private const int StartInventorySlot = 3;
		public event Action<ItemInventory> OnChangeInventorySize;
		public event Action<ItemInventory, int> OnRemove;
		public event Action<ItemInventory, int> OnUse;
		public event Action<ItemInventory, int> OnGet;
		public event Action<ItemInventory, int> OnCandidateAdded;
		
		//==================================================Properties	
		public int InventoryAmount { get; private set; }
		public IEnumerable<ItemBase> Items => _items.Select(item => item);

		//==================================================Fields	
		private List<ItemBase> _items = new();
		private Queue<int> _candidate = new();

		//==================================================Constructors	
		public ItemInventory() {
			AddInventorySize(StartInventorySlot);
		}
		
		//==================================================Merthods	
		
		public void AddInventorySize(int pAmount) {
			if (pAmount < 0) throw new ArgumentOutOfRangeException($"pAmount must bigger then 0({pAmount})");
			InventoryAmount += pAmount;
			for (int i = 0; i < pAmount; i++) {
				_items.Add(null);
			}
			OnChangeInventorySize?.Invoke(this);
		}

		public void Use(int pIdx) {
			if (_items.Count <= pIdx) return;
			_items[pIdx]?.Use();
			_items[pIdx] = null;
			OnUse?.Invoke(this, pIdx);
		}

		public int GetItemId(int pIdx) => _items[pIdx]?.Id ?? -1;
		public void AddItem(int pId) => AddItem(pId, -1);
		
		public void SelectItem(int pIdx) {
			var id = _candidate.Dequeue();
			if (pIdx == -1) return;
			AddItem(id, pIdx);
			OnRemove?.Invoke(this, pIdx);
		}
		
		//pIdx != -1 -> force work
		private void AddItem(int pId, int pIdx) {

			if (pIdx == -1) {
				pIdx = _items.FindIndex(item => item == null);
				if (pIdx == -1) {
					_candidate.Enqueue(pId);
					OnCandidateAdded?.Invoke(this, pId);
					return;
				}
			}
				
			var targetItem = Type.GetType($"Item.Item{pId}")!;
			var item = (Activator.CreateInstance(targetItem) as ItemBase)!;
			_items[pIdx] = item;
			OnGet?.Invoke(this, pIdx);
		}
	}
}