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

		public void Show(DataDesc pData) {
			_window.SetActive(true);
			_name.text = pData.Name;
			_desc.text = pData.Desc;
		}

		public void Hide(string pName) {
			if (_name.text != pName) return;
			_window.SetActive(false);
		}
	}
}