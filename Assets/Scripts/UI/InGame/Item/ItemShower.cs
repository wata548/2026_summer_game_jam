using Data;
using TMPro;
using UI.InGame.Info;
using UnityEngine;
using UnityEngine.UI;

namespace UI.InGame.Item {
	public class ItemShower: DataGenerator {
		[SerializeField] private Image _image; 
		[SerializeField] private TMP_Text _keyShower;
		private int _id = 0;
		public void SetItem(int pId, string pLabel) {
			_id = pId;
			_image.sprite = DataImage.Get(pId);
			_keyShower.text = pLabel;
		}

		public override string Name => _id == 0 
			? "" 
			: DataTables.Instance.ItemsDesc.Get(_id).Name;
		public override string Context => _id == 0 
			? "" 
			: DataTables.Instance.ItemsDesc.Get(_id).Desc;
		
	}
}