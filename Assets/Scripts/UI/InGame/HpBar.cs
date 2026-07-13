using DG.Tweening;
using Entity;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.InGame {
	public class HpBar: MonoBehaviour {
		const float AnimationDuration = 0.6f;
		[SerializeField] private Image _fill;
		[SerializeField] private Image _decrease;
		[SerializeField] private Image _guard;
		[SerializeField] private TMP_Text _context;
		private Tween _animation;
		private int _lastGuard = 0;

		private void CalcGuard(IEntity pTarget, int _ = 0) {
			_animation?.Kill();
			_guard.enabled = true;
			var guard = _lastGuard;
			_lastGuard = pTarget.Guard;
			_animation = DOTween.To(() => guard, x => {
					guard = x;
					_context.text = $"{pTarget.Hp} / {pTarget.MaxHp} + {guard}";
				}, _lastGuard, AnimationDuration)
				.OnComplete(() => _guard.enabled = pTarget.Guard > 0)
				.SetEase(Ease.InCirc);
		}
		
		private void UpdateContext(IEntity pTarget) {

			var fillAmount = _decrease.fillAmount;
			var ratio = (float)pTarget.Hp / pTarget.MaxHp;
			_fill.fillAmount = ratio;
			var curHp = Mathf.CeilToInt(fillAmount * pTarget.MaxHp);
			var needDecreaseUpdate = curHp >= pTarget.Hp;
			if (!needDecreaseUpdate) _decrease.fillAmount = ratio;
			
			if (pTarget.Guard > 0) {
				CalcGuard(pTarget);
				return;
			}

			_animation?.Kill();
			_guard.enabled = false;
			_animation = DOTween.To(() => curHp, x => {
					curHp = x;
					_context.text = $"{curHp} / {pTarget.MaxHp}";
					if(needDecreaseUpdate)
						_decrease.fillAmount = (float)curHp / pTarget.MaxHp;
				}, pTarget.Hp, AnimationDuration)
				.SetEase(Ease.InCirc);
		}

		private void Start() {
			Player.Instance.OnHpChange += UpdateContext;
			Player.Instance.OnAddGuard += CalcGuard;
		}
	}
}