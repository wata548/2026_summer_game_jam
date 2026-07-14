using Entity;
using StatusEffect;
using UnityEngine;

namespace UI.InGame {
	public class StatusShowerManager: MonoBehaviour {
		[SerializeField] private StatusShower _shower;
		[SerializeField] private Transform _folder;
		private void Start() {
			Player.Instance.OnAddStatusEffect += Refresh;
		}

		private void Refresh(IEntity pTarget, StatusEffectBase pEffect) =>
			Instantiate(_shower, _folder).Set(pEffect);
	}
}