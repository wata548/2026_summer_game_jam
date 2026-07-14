using System;
using Data;
using StatusEffect;
using TMPro;
using UI.InGame.Info;
using UnityEngine;
using UnityEngine.UI;

namespace UI.InGame {
	public class StatusShower: DataGenerator {
		public override string Name => _effect?.Desc.Name ?? "";
		public override string Context => _effect?.Context ?? "";

		private StatusEffectBase _effect;
		[SerializeField] private Image _icon;
		[SerializeField] private TMP_Text _remainTime;

		public void Set(StatusEffectBase pEffect) {
			_effect = pEffect;
			_icon.sprite = DataImage.Get(pEffect.Id);
		}

		protected override void Update() {
			base.Update();
			_remainTime.text = $"{_effect.Duration:N1}s";
			if(!_effect.Alive) Destroy(gameObject);
		}
	}
}