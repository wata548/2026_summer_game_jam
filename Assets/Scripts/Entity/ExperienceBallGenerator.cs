using Entity;
using Extension;
using Extension.ObjectPool;
using UnityEngine;

namespace Data.Entity {
	public class ExperienceBallGenerator: MonoSingleton<ExperienceBallGenerator> {
		protected override bool IsNarrowSingleton => true;
		[SerializeField] private ExperienceBall _prefab;
		public ObjPool<ExperienceBall> Pool { get; private set; }
		private void Awake() {
			Pool = new(_prefab);
		}
	}
}