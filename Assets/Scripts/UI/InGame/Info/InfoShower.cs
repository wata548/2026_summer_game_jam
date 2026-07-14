using System;
using Data.Info;
using Extension;
using TMPro;
using UnityEngine;

namespace UI.InGame.Info {
	public class InfoShower: MonoSingleton<InfoShower> {
		protected override bool IsNarrowSingleton => false;
		[SerializeField] private GameObject _window;
		[SerializeField] private TMP_Text _name;
		[SerializeField] private TMP_Text _desc;
		private RectTransform _rect;
		private bool _show;

		public void Show(DataDesc pData) {
			if (string.IsNullOrWhiteSpace(pData.Name)) return;
			_show = true;
			_window.SetActive(true);
			_name.text = pData.Name;
			_desc.text = pData.Desc;
		}

		public void Hide(string pName) {
			if (_name.text != pName) return;
			_show = false;
			_window.SetActive(false);
		}

		private void Awake() {
			_rect = _window.transform as RectTransform;
		}

		private void Update() {
			if (!_show) return;
			var pos = Input.mousePosition;
			var pivot = new Vector2(
				pos.x + _rect.sizeDelta.x > Screen.width ? 1 : 0,
				pos.y + _rect.sizeDelta.y > Screen.height ? 1 : 0
			);
			_rect.pivot = pivot;
			_rect.position = pos;
		}
	}
}