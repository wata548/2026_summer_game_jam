using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.InGame.Item {
	public class ItemShower: MonoBehaviour {
		[SerializeField] private Image _image; 
		[SerializeField] private TMP_Text _keyShower; 
		public void SetItem(int pId, string pLabel) {
			_image.sprite = DataImage.Get(pId);
			_keyShower.text = pLabel;
		}
	}
}