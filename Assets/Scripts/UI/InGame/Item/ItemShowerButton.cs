using System;
using Entity;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.UI;

namespace UI.InGame.Item {
	[RequireComponent(typeof(Button))]
	public class ItemShowerButton: ItemShower {

		private static int _lastClick = -2;
		private static Action _close;

		[SerializeField] private Sprite _activeFrame;
		[SerializeField] private Sprite _unactiveFrame;
		[SerializeField] private Image _frame;
		private int _idx = 0;
		public static void Init(Action pClose) => _close = pClose;

		public void SetIdx(int pIdx) {
			_idx = pIdx;
			GetComponent<Button>().onClick.AddListener(Click);
		}

		private void Click() {
			if (_lastClick == _idx) {
				Player.Instance.ItemInventory.SelectItem(_lastClick);
				_lastClick = -2;
				_close?.Invoke();
			}
			else
				_lastClick = _idx;
		}

		private void Update() {
			_frame.sprite = _lastClick == _idx
				? _activeFrame
				: _unactiveFrame;
		}
	}
}