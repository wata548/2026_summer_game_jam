using System;
using System.Collections.Generic;
using System.Linq;

namespace Item {
	public class ItemInventory {

		private const int StartInventorySlot = 3;
		public event Action<ItemInventory> OnChangeInventorySize;
		public event Action<ItemInventory> OnChangedItem;
		public event Action<ItemInventory, int> OnRemove;
		public event Action<ItemInventory, int> OnUse;
		public event Action<ItemInventory, int> OnGet;
		public event Action<ItemInventory, int> OnCandidateAdd;
		
		//==================================================Properties	
		public int InventoryAmount { get; private set; }
		public IEnumerable<ItemDesc> Items => _items.Select(item => item.Info);

		//==================================================Fields	
		private List<ItemBase> _items = new();
		private Queue<int> _candidate;

		//==================================================Constructors	
		public ItemInventory() {
			AddInventorySize(StartInventorySlot);
		}
		
		//==================================================Merthods	
		public void AddInventorySize(int pAmount) {
			if (pAmount < 0) throw new ArgumentOutOfRangeException($"pAmount must bigger then 0({pAmount})");
			InventoryAmount += pAmount;
			for (int i = 0; i < InventoryAmount; i++) {
				_items.Add(null);
			}
			OnChangeInventorySize?.Invoke(this);
		}

		public void Use(int pIdx) {
			_items[pIdx]?.Use();
			_items[pIdx] = null;
			OnChangedItem?.Invoke(this);
			OnUse?.Invoke(this, pIdx);
		}

		public void GetItem(int pId) => GetItem(pId, -1);
		
		public void SelectItem(int pIdx) {
			var id = _candidate.Dequeue();
			if (pIdx == -1) return;
			GetItem(id, pIdx);
			OnRemove?.Invoke(this, pIdx);
		}
		
		//pIdx != -1 -> force work
		private void GetItem(int pId, int pIdx) {

			if (pIdx == -1) {
				pIdx = _items.FindIndex(item => item == null);
				if (pIdx == -1) {
					_candidate.Enqueue(pId);
					OnCandidateAdd?.Invoke(this, pId);
					return;
				}
			}
				
			var targetItem = Type.GetType($"Item.Item{pId}")!;
			var item = (Activator.CreateInstance(targetItem) as ItemBase)!;
			OnChangedItem?.Invoke(this);
			OnGet?.Invoke(this, pIdx);
			_items[pIdx] = item;
		}
	}
}