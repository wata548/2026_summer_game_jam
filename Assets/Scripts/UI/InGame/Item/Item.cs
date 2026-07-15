using Entity;
using Extension.ObjectPool;
using UnityEngine;
using UnityEngine.UI;

namespace UI.InGame.Item {
	[RequireComponent(typeof(SpriteRenderer))]
	public class Item: ObjBase<Item> {

		private SpriteRenderer _sprite;
		private int _code;

		private void Awake() => _sprite = GetComponent<SpriteRenderer>();
		
		public void Set(int pId) {
			_code = pId;
			_sprite.sprite = DataImage.Get(pId);
		}

		private void OnTriggerEnter2D(Collider2D other) {
			if (!other.gameObject.CompareTag("Player")) return;
			Player.Instance.ItemInventory.AddItem(_code);
			Destroy(gameObject);
		}
	}
}