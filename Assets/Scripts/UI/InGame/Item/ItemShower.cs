using UnityEngine;
using UnityEngine.UI;

namespace UI.InGame.Item {
	[RequireComponent(typeof(Image))]
	public class ItemShower: MonoBehaviour {
		private Image _image; 
		public void SetItem(int pId) {
			_image.sprite = DataImage.Get(pId);
		}

		private void Awake() {
			_image = GetComponent<Image>();
		}
	}
}