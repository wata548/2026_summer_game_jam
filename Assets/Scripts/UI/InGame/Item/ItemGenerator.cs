using System;
using Extension;
using Extension.ObjectPool;
using UnityEngine;

namespace UI.InGame.Item {
	public class ItemGenerator: MonoSingleton<ItemGenerator> {
		protected override bool IsNarrowSingleton => true;
		[SerializeField] private Item _prefab;
		private ObjPool<Item> _pool;

		public Item Get() => _pool.Get(); 
		
		private void Awake() {
			_pool = new(_prefab);
		}
	}
}