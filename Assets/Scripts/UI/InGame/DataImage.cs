using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UI.InGame {
	public static class DataImage {
		static DataImage() {
			Sprites = Resources.LoadAll<Sprite>("NumberImages")
				.ToDictionary(sprite => int.Parse(sprite.name), sprite => sprite);
		}

		public static readonly IReadOnlyDictionary<int, Sprite> Sprites;

		public static Sprite Get(int pId) {
			if (!Sprites.TryGetValue(pId, out var value))
				value = Sprites[-1];
			return value;
		}
	}
}