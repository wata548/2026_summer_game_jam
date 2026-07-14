using System;
using Data.Info;
using UnityEngine;

namespace UI.InGame.Info {
	public abstract class DataGenerator: MonoBehaviour {
		public abstract string Name { get; } 
		public abstract string Context { get; } 
		
		public void OnMouseEnter() {
			InfoShower.Instance.Show(new(Name, Context));
		}

		public void OnMouseExit() {
			InfoShower.Instance.Hide(Name);
		}
	}
}