using System;
using Data.Info;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.InGame.Info {
	public abstract class DataGenerator: MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
		public abstract string Name { get; } 
		public abstract string Context { get; }
		private bool _active = false;  
		
		public void OnPointerEnter(PointerEventData eventData) {
			if (_active) return;
			_active = true;
			InfoShower.Instance.Show(new(Name, Context));
		}
		public void OnPointerExit(PointerEventData eventData) {
			if (!_active) return;
			_active = false;
			InfoShower.Instance.Hide(Name);
		}

		protected virtual void Update() {
			if (!_active) return;
			InfoShower.Instance.Show(new(Name, Context));
		}

		private void OnDisable() {
			OnPointerExit(null);
		}

		private void OnDestroy() {
			OnPointerExit(null);
		}
	}
}