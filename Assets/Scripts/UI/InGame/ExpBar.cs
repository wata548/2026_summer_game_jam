using Data.Level;
using DG.Tweening;
using Entity;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.InGame {
	public class ExpBar: MonoBehaviour {
		const float AnimationDuration = 0.6f;
		[SerializeField] private Image _fill;
		[SerializeField] private TMP_Text _context;
		private Tween _animation;

		private void LevelUp(Level pLevel) => _fill.fillAmount = 0;

		private void OnGetExp(Level pLevel) {
			_animation?.Kill();
			var cur = Mathf.FloorToInt(_fill.fillAmount * pLevel.NeedExp);
			_animation = DOTween.To(
				() => cur,
				x => {
					cur = x;
					_context.text = $"Lv {pLevel.CurLevel}: EXP {cur} / {pLevel.NeedExp}";
					_fill.fillAmount = (float)x / pLevel.NeedExp;
				},
				pLevel.Exp,
				AnimationDuration
			);
		}
		
		private void Start() {
			var level = Player.Instance.Level;
			level.OnGetExp += OnGetExp;
			level.OnLevelUp += LevelUp;
			level.GetExp(0);
		}
	}
}